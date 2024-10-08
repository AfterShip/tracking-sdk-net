/*
 * This code was auto generated by AfterShip SDK Generator.
 * Do not edit the class manually.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AfterShipTracking
{
    /// <summary>
    /// Standard client to make requests to API, using
    /// <see cref="System.Net.Http.HttpClient"/> to send HTTP requests. It can gather telemetry
    /// about request latency (via <see cref="RequestTelemetry"/>) and automatically retry failed
    /// requests when it's safe to do so.
    /// </summary>
    public class SystemNetHttpClient : IHttpClient
    {
        /// <summary>Default maximum number of retries made by the client.</summary>
        public const int DefaultMaxNumberRetries = 2;

        /// <summary>
        /// Default timeout in millseconds.
        /// </summary>
        public const int DefaultTimeout = 30000;

        private readonly System.Net.Http.HttpClient httpClient;

        private readonly object randLock = new object();

        private readonly Random rand = new Random();

        private string userAgent;

        private int timeout;

        private string baseUrl { get; set; }

        private string proxy { get; set; }

        private Authenticator authenticator { get; set; }

        private RateLimit rateLimit = new RateLimit();

        static SystemNetHttpClient()
        {
            // Enable support for TLS 1.2, as Tracking's API requires it. This should only be
            // necessary for .NET Framework 4.5 as more recent runtimes should have TLS 1.2 enabled
            // by default, but it can be disabled in some environments.
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |
                SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemNetHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="System.Net.Http.HttpClient"/> client to use. If <c>null</c>, an HTTP
        /// client will be created with default parameters.
        /// </param>
        /// <param name="maxNetworkRetries">
        /// The maximum number of times the client will retry requests that fail due to an
        /// intermittent problem.
        /// </param>

        public SystemNetHttpClient(
         String baseUrl = null,
         Authenticator authenticator = null,
         int maxNetworkRetries = DefaultMaxNumberRetries,
         int timeout = DefaultTimeout,
         string userAgent = "",
         string proxy = null
        )
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw ErrorCode.GenSDKError(ErrorCode.INVALID_REQUEST, "Base url empty");
            }

            this.baseUrl = baseUrl;
            this.proxy = proxy;
            this.MaxNetworkRetries = maxNetworkRetries;
            this.userAgent = userAgent;
            this.timeout = timeout;
            this.authenticator = authenticator;
            this.rateLimit = new RateLimit();
            this.httpClient = BuildSystemNetHttpClient(this.timeout, this.proxy);
        }

        /// <summary>Default timespan before the request times out.</summary>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(30);

        /// <summary>
        /// Maximum sleep time between tries to send HTTP requests after network failure.
        /// </summary>
        public static TimeSpan MaxNetworkRetriesDelay => TimeSpan.FromSeconds(5);

        /// <summary>
        /// Minimum sleep time between tries to send HTTP requests after network failure.
        /// </summary>
        public static TimeSpan MinNetworkRetriesDelay => TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// Gets how many network retries were configured for this client.
        /// </summary>
        public int MaxNetworkRetries { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the client should sleep between automatic
        /// request retries.
        /// </summary>
        /// <remarks>This is an internal property meant to be used in tests only.</remarks>
        internal bool NetworkRetriesSleep { get; set; } = true;

        internal int NumRetries { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="System.Net.Http.HttpClient"/> class
        /// with default parameters.
        /// </summary>
        /// <returns>The new instance of the <see cref="System.Net.Http.HttpClient"/> class.</returns>
        public static HttpClient BuildSystemNetHttpClient(int timeoutMs= DefaultTimeout, string proxyUrl = null)
        {
            if (timeoutMs <=0) {
                timeoutMs = DefaultTimeout;
            }
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMs);
            if (string.IsNullOrEmpty(proxyUrl))
            {
                return new HttpClient
                {
                    Timeout = timeout,
                };
            }
            else
            {
                // Create HttpClientHandler
                HttpClientHandler handler = new HttpClientHandler
                {
                    Proxy = new WebProxy
                    {
                        Address = new Uri(proxyUrl),
                        UseDefaultCredentials = false,
                    },
                    UseProxy = true
                };


                //  HttpClient
                return new HttpClient(handler)
                {
                    Timeout = timeout,
                };

            }
        }


        public Response MakeRequest(Request request)
        {
            var task = MakeRequestAsync(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Sends a request to API as an asynchronous operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response> MakeRequestAsync(
            Request request)
        {
            var (response, retries) = await this.SendHttpRequest(request).ConfigureAwait(false);

            var reader = new StreamReader(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false));

            return new Response(
                response.StatusCode,
                response.Headers,
                await reader.ReadToEndAsync().ConfigureAwait(false))
            {
                NumRetries = retries,
            };
        }



        private async Task<(HttpResponseMessage responseMessage, int retries)> SendHttpRequest(
            Request request)
        {
            Exception? requestException;
            HttpResponseMessage? response = null;
            int retry = 0;

            while (true)
            {
                requestException = null;
                 if (retry > this.MaxNetworkRetries)
                {
                    requestException = ErrorCode.GenSDKError(ErrorCode.TIMED_OUT, ErrorCode.TIMED_OUT);
                    break;
                }
                var httpRequest = this.BuildRequestMessage(request);

                var stopwatch = Stopwatch.StartNew();
                // if (this.IsRateOverflow())
                // {
                //     throw ErrorCode.GenSDKError(ErrorCode.RATE_LIMIT_EXCEEDED, ErrorCode.RATE_LIMIT_EXCEEDED);
                // }
                try
                {
                    response = await this.httpClient.SendAsync(httpRequest)
                        .ConfigureAwait(false);
                }
                catch (HttpRequestException)
                {
                    requestException = ErrorCode.GenSDKError(ErrorCode.INTERNAL_ERROR, ErrorCode.INTERNAL_ERROR); ;
                }
                catch (OperationCanceledException)
                {
                    requestException = ErrorCode.GenSDKError(ErrorCode.TIMED_OUT,ErrorCode.TIMED_OUT);
                }

                stopwatch.Stop();

                // SetRateLimit(this.rateLimit, response);

                if (!this.ShouldRetry(
                    retry,
                    requestException != null,
                    response?.StatusCode,
                    response?.Headers))
                {
                    break;
                }

                retry += 1;
                await Task.Delay(SleepTime(retry)).ConfigureAwait(false);
            }

            if (requestException != null)
            {
                throw requestException;
            }

            return (response, retry);
        }


        private bool ShouldRetry(
            int numRetries,
            bool error,
            HttpStatusCode? statusCode,
            HttpHeaders headers)
        {
            // Do not retry if we are out of retries.
            if (numRetries >= this.MaxNetworkRetries)
            {
                return false;
            }

            // Retry on connection error.
            if (error == true)
            {
                return true;
            }


            // Retry on 500, 503, and other internal errors.
            if (statusCode.HasValue && ((int)statusCode.Value >= 500))
            {
                return true;
            }

            return false;
        }

        private HttpRequestMessage BuildRequestMessage(Request request)
        {
            string url = this.baseUrl + request.Path;

            // query
            if (request.QueryParams != null && request.QueryParams.Count > 0)
            {
                url += "?" + string.Join("&", request.QueryParams.Select(p => $"{p.Key}={p.Value}"));
            }


            HttpRequestMessage requestMessage = new HttpRequestMessage(request.Method, url);

            // default headers
            Dictionary<string, string> defaultHeaders = BuildDefaultHeader(this.userAgent);
            HttpHeaders headers = requestMessage.Headers;
            foreach (var header in defaultHeaders)
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            // Custom header
            foreach (var header in request.HeaderParams)
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            // auth headers
            headers.TryAddWithoutValidation("as-api-key", authenticator.ApiKey);

            // body
            if (request.Body != null)
            {
                requestMessage.Content = new StringContent(request.Body, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }


            // compute signature
            this.authenticator.Sign(requestMessage);
            return requestMessage;
        }

        private TimeSpan SleepTime(int retryAttempt)
        {
            int delayBase = 3;
            int delay = delayBase * (int)Math.Pow(2, retryAttempt - 1);
            double jitter = delay * (new Random().NextDouble() - 0.5);
            int finalDelay = (int)(Math.Max(1, delay + jitter) * 1000);
            return TimeSpan.FromMilliseconds(finalDelay);

        }


        public Dictionary<string, string> BuildDefaultHeader(string userAgent)
        {
            userAgent = string.IsNullOrEmpty(userAgent) ?  AfterShipConfiguration.DEFAULT_USER_AGENT: userAgent;
            Dictionary<string, string> headers = new();
            headers.Add("content-type", "application/json");
            headers.Add("date", DateTime.UtcNow.ToString("r"));
            headers.Add("user-agent", userAgent);
            headers.Add("aftreship-client", AfterShipConfiguration.DEFAULT_USER_AGENT);
            return headers;
        }

        public void BuildAuthHeader(HttpRequestMessage request)
        {
            this.authenticator.Sign(request);
        }

        static void SetRateLimit(RateLimit rateLimit, HttpResponseMessage response)
        {
            if (rateLimit == null || response == null || response.Headers == null)
            {
                return;
            }

            if (response.Headers.TryGetValues("x-ratelimit-reset", out var resetValues) && !string.IsNullOrEmpty(resetValues.FirstOrDefault()))
            {
                if (long.TryParse(resetValues.First(), out var reset))
                {
                    rateLimit.Reset = reset;
                }
            }

            if (response.Headers.TryGetValues("x-ratelimit-limit", out var limitValues) && !string.IsNullOrEmpty(limitValues.FirstOrDefault()))
            {
                if (int.TryParse(limitValues.First(), out var limit))
                {
                    rateLimit.Limit = limit;
                }
            }

            if (response.Headers.TryGetValues("x-ratelimit-remaining", out var remainingValues) && !string.IsNullOrEmpty(remainingValues.FirstOrDefault()))
            {
                if (int.TryParse(remainingValues.First(), out var remaining))
                {
                    rateLimit.Remaining = remaining;
                }
            }
        }

        private bool IsRateOverflow()
        {
            return rateLimit?.IsExceeded() ?? false;
        }

    }

    public class RateLimit
    {
        public long Reset { get; set; }
        public int Limit { get; set; }
        public int Remaining { get; set; }

        public bool IsExceeded()
        {
            return Remaining == 0 && Reset >= DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}


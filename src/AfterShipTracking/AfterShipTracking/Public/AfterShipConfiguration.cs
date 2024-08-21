/*
 * This code was auto generated by AfterShip SDK Generator.
 * Do not edit the class manually.
 */
using System;

namespace AfterShipTracking
{
    public static class AfterShipConfiguration
    {
        public const string AUTHENTICATION_TYPE_API_KEY = "API_KEY";
        public const string AUTHENTICATION_TYPE_AES = "AES";
        public const string AUTHENTICATION_TYPE_RSA = "RSA";

        public const string SDK_PREFIX = "AFTERSHIP_TRACKING_SDK";
        public const int DEFAULT_MAX_RETRY = 2;
        public const int DEFAULT_TIMEOUT = 10000;
        public const string DEFAULT_USER_AGENT = "tracking-sdk-net/8.0.0 (https://www.aftership.com) System.Net.Http.HttpClient/0.0.0";
        public const string DEFAULT_DOMAIN = "https://api.aftership.com";

        private static string domain;
        private static int timeout;
        private static int maxRetry;
        private static string userAgent;
        private static string proxy;
        private static string apiKey;
        private static string apiSecret;
        private static string authenticationType;

        /// <summary>
        /// Custom API domain.
        /// </summary>
        public static string Domain
        {
            get
            {
                if (!string.IsNullOrEmpty(domain))
                {
                    return domain;
                }
                return Environment.GetEnvironmentVariable(SDK_PREFIX+"_DOMAIN") ?? DEFAULT_DOMAIN;
            }

            set
            {

                domain = value;
            }
        }

        /// <summary>
        /// Custom API domain.
        /// </summary>
        public static int MaxRetry
        {
            get
            {
                if (maxRetry > 0)
                {
                    return maxRetry;
                }
                if (int.TryParse(Environment.GetEnvironmentVariable(SDK_PREFIX + "_MAX_RETRY"), out int n) && n > 0)
                {
                    return n;
                }
                return DEFAULT_MAX_RETRY;
            }
            set
            {
                maxRetry = value;
            }
        }

        /// <summary>
        /// Max request timeout in milliseconds.
        /// </summary>
        public static int Timeout
        {
            get
            {
                if (timeout >0 )
                {
                    return timeout;
                }
                if (int.TryParse(Environment.GetEnvironmentVariable(SDK_PREFIX + "_TIMEOUT"), out int n) && n > 0)
                {
                      return n;
                }
                return DEFAULT_TIMEOUT;
            }

            set
            {
                timeout = value;
            }
        }

        /// <summary>
        /// Custom API userAgent.
        /// </summary>
        public static string UserAgent
        {
            get
            {
                if (!string.IsNullOrEmpty(userAgent))
                {
                    return userAgent;
                }
                return Environment.GetEnvironmentVariable(SDK_PREFIX+"_USER_AGENT") ?? null;
            }

            set
            {
                userAgent = value;

            }
        }

        /// <summary>
        /// Custom API Proxy.
        /// </summary>
        public static string Proxy
        {
            get
            {
                if (!string.IsNullOrEmpty(proxy))
                {
                    return proxy;
                }
                return Environment.GetEnvironmentVariable(SDK_PREFIX+"_PROXY") ?? "";
            }

            set
            {
                proxy = value;
            }
        }

        /// <summary>
        /// Custom API API key.
        /// </summary>
        public static string ApiKey
        {
            get
            {
                if (!string.IsNullOrEmpty(apiKey))
                {
                    return apiKey;
                }
                return Environment.GetEnvironmentVariable(SDK_PREFIX+"_API_KEY") ?? "";
            }

            set
            {
                apiKey = value;
            }
        }

        /// <summary>
        /// AfterShip API secret for AES or RSA authentication method.
        /// </summary>
        public static string ApiSecret
        {
            get
            {
                if (!string.IsNullOrEmpty(apiSecret))
                {
                    return apiSecret;
                }
                return Environment.GetEnvironmentVariable(SDK_PREFIX+"_API_SECRET") ?? "";
            }

            set
            {
                apiSecret = value;
            }
        }

        /// <summary>
        /// AfterShip API Authentication method. Allowed value: API_KEY , AES , RSA
        /// </summary>
        public static string AuthenticationType
        {
            get
            {
                if (!string.IsNullOrEmpty(authenticationType))
                {
                    return authenticationType;
                }
                return Environment.GetEnvironmentVariable(SDK_PREFIX+"_AUTHENTICATION_TYPE") ?? AUTHENTICATION_TYPE_API_KEY;
            }

            set
            {
                authenticationType = value;
            }
        }
    }
}

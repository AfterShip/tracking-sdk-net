/*
 * This code was auto generated by AfterShip SDK Generator.
 * Do not edit the class manually.
 */
using System;
using System.Net.Http;

namespace AfterShipTracking
{
    public class TrackingService : BaseResourceService
    {
        IHttpClient HttpClient;

        public TrackingService(IHttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public Tracking GetTrackingById(string id,  GetTrackingByIdOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{id}";
            if (string.IsNullOrEmpty(id))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `id` is invalid");
            }
            Request request = new Request(
                HttpMethod.Get,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking DeleteTrackingById(string id,  DeleteTrackingByIdOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{id}";
            if (string.IsNullOrEmpty(id))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `id` is invalid");
            }
            Request request = new Request(
                HttpMethod.Delete,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking RetrackTrackingBySlugTrackingNumber(string slug, string trackingNumber,  RetrackTrackingBySlugTrackingNumberOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{slug}/{trackingNumber}/retrack";
            if (string.IsNullOrEmpty(slug))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `slug` is invalid");
            }
            if (string.IsNullOrEmpty(trackingNumber))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `tracking_number` is invalid");
            }
            Request request = new Request(
                HttpMethod.Post,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public GetTrackingsResponseTrackingListData GetTrackings( GetTrackingsOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings";
            Request request = new Request(
                HttpMethod.Get,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<GetTrackingsResponseTrackingListData>(response);
        }
        public Tracking CreateTracking( CreateTrackingOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings";
            Request request = new Request(
                HttpMethod.Post,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking RetrackTrackingById(string id,  RetrackTrackingByIdOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{id}/retrack";
            if (string.IsNullOrEmpty(id))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `id` is invalid");
            }
            Request request = new Request(
                HttpMethod.Post,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking MarkTrackingCompletedById(string id,  MarkTrackingCompletedByIdOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{id}/mark-as-completed";
            if (string.IsNullOrEmpty(id))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `id` is invalid");
            }
            Request request = new Request(
                HttpMethod.Post,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking UpdateTrackingBySlugTrackingNumber(string slug, string trackingNumber,  UpdateTrackingBySlugTrackingNumberOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{slug}/{trackingNumber}";
            if (string.IsNullOrEmpty(slug))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `slug` is invalid");
            }
            if (string.IsNullOrEmpty(trackingNumber))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `tracking_number` is invalid");
            }
            Request request = new Request(
                HttpMethod.Put,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking DeleteTrackingBySlugTrackingNumber(string slug, string trackingNumber,  DeleteTrackingBySlugTrackingNumberOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{slug}/{trackingNumber}";
            if (string.IsNullOrEmpty(slug))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `slug` is invalid");
            }
            if (string.IsNullOrEmpty(trackingNumber))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `tracking_number` is invalid");
            }
            Request request = new Request(
                HttpMethod.Delete,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking MarkTrackingCompletedBySlugTrackingNumber(string slug, string trackingNumber,  MarkTrackingCompletedBySlugTrackingNumberOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{slug}/{trackingNumber}/mark-as-completed";
            if (string.IsNullOrEmpty(slug))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `slug` is invalid");
            }
            if (string.IsNullOrEmpty(trackingNumber))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `tracking_number` is invalid");
            }
            Request request = new Request(
                HttpMethod.Post,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking UpdateTrackingById(string id,  UpdateTrackingByIdOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{id}";
            if (string.IsNullOrEmpty(id))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `id` is invalid");
            }
            Request request = new Request(
                HttpMethod.Put,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
        public Tracking GetTrackingBySlugTrackingNumber(string slug, string trackingNumber,  GetTrackingBySlugTrackingNumberOptions? options = null)
        {
            string path = $"/tracking/2024-07/trackings/{slug}/{trackingNumber}";
            if (string.IsNullOrEmpty(slug))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `slug` is invalid");
            }
            if (string.IsNullOrEmpty(trackingNumber))
            {
               throw ErrorCode.GenSDKError(ErrorCode.REQUEST_ERROR,"request error"+": `tracking_number` is invalid");
            }
            Request request = new Request(
                HttpMethod.Get,
                path,
                options
            );

            var response = this.HttpClient.MakeRequest(request);
            return ProcessData<Tracking>(response);
        }
    }
}


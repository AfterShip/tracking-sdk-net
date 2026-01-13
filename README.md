# AfterShip Tracking API library for C#

This library allows you to quickly and easily use the AfterShip Tracking API via C#.

For updates to this library, see our [GitHub release page](https://github.com/AfterShip/tracking-sdk-net/releases).

If you need support using AfterShip products, please contact support@aftership.com.

## Table of Contents

- [AfterShip Tracking API library for C#](#aftership-tracking-api-library-for-c#)
  - [Table of Contents](#table-of-contents)
  - [Before you begin](#before-you-begin)
    - [API and SDK Version](#api-and-sdk-version)
  - [Quick Start](#quick-start)
    - [Installation](#installation)
  - [Constructor](#constructor)
    - [Example](#example)
  - [Rate Limiter](#rate-limiter)
  - [Error Handling](#error-handling)
    - [Error List](#error-list)
  - [Endpoints](#endpoints)
    - [/trackings](#trackings)
    - [/couriers](#couriers)
    - [/courier-connections](#courier-connections)
    - [/estimated-delivery-date](#estimated-delivery-date)
  - [Help](#help)
  - [License](#license)


## Before you begin

Before you begin to integrate:

- [Create an AfterShip account](https://admin.aftership.com/).
- [Create an API key](https://organization.automizely.com/api-keys).
- [Install .Net](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) version 6.0 or later.

### API and SDK Version

- SDK Version: 
- API Version: 2026-01
## Quick Start

### Installation
Using the [.NET Core command-line interface (CLI) tools]:

```sh
dotnet add package AfterShipTracking
```

Using the [NuGet Command Line Interface (CLI)]:

```sh
nuget install AfterShipTracking
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "AfterShipTracking".
5. Click on the AfterShipTracking package, select the appropriate version in the
   right-tab and click *Install*.

For with Visual Studio Code:
1. Open the Command Palette then type "NuGet Package Manager"
2. In the opened window, search for "AfterShipTracking".
3. Select the AfterShipTracking package and the package version.

## Constructor

Create AfterShip instance with options

| Name       | Type   | Required | Description                                                                                                                       |
| ---------- | ------ | -------- | --------------------------------------------------------------------------------------------------------------------------------- |
| api_key    | string | ✔        | Your AfterShip API key                                                                                                            |
| auth_type  | enum   |          | Default value: `AuthType.API_KEY` <br > AES authentication: `AuthType.AES` <br > RSA authentication: `AuthType.RSA`               |
| api_secret | string |          | Required if the authentication type is `AuthType.AES` or `AuthType.RSA`                                                           |
| domain     | string |          | AfterShip API domain. Default value: https://api.aftership.com                                                                    |
| user_agent | string |          | User-defined user-agent string, please follow [RFC9110](https://www.rfc-editor.org/rfc/rfc9110#field.user-agent) format standard. |
| proxy      | string |          | HTTP proxy URL to use for requests. <br > Default value: `null` <br > Example: `http://192.168.0.100:8888`                        |
| max_retry  | number |          | Number of retries for each request. Default value: 2. Min is 0, Max is 10.                                                        |
| timeout    | number |          | Timeout for each request in milliseconds.                                                                                         |

### Example

```csharp
using AfterShipTracking;
class Program
{
    static void Main()
    {
        try
        {
            AfterShipClient client = new AfterShipClient(
                apiKey: "YOUR_API_KEY",
                apiSecret: "YOUR_AES_SECRET",
                authenticationType: AfterShipConfiguration.AUTHENTICATION_TYPE_AES
            );

            GetTrackingByIdOptions options = new GetTrackingByIdOptions();
                GetTrackingByIdResponse response = client.Tracking.GetTrackingById("valid_value",options);
                if (response != null)
                {
                    Console.WriteLine(response);
                }
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

```

## Rate Limiter

See the [Rate Limit](https://www.aftership.com/docs/tracking/quickstart/rate-limit) to understand the AfterShip rate limit policy.

## Error Handling

The SDK will return an error object when there is any error during the request, with the following specification:

| Name            | Type   | Description                    |
| --------------- | ------ | ------------------------------ |
| message         | string | Detail message of the error    |
| code            | enum   | Error code enum for API Error. |
| meta_code       | number | API response meta code.        |
| status_code     | number | HTTP status code.              |
| response_body   | string | API response body.             |
| response_header | object | API response header.           |


### Error List

| code                              | meta_code       | status_code     | message                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| --------------------------------- | --------------- | --------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| INVALID_REQUEST | 400 | 400 | The request was invalid or cannot be otherwise served. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| INVALID_JSON | 4001 | 400 | Invalid JSON data. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TRACKING_ALREADY_EXIST | 4003 | 400 | Tracking already exists. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TRACKING_DOES_NOT_EXIST | 4004 | 404 | Tracking does not exist. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TRACKING_NUMBER_INVALID | 4005 | 400 | The value of tracking_number is invalid. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TRACKING_REQUIRED | 4006 | 400 | tracking object is required. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TRACKING_NUMBER_REQUIRED | 4007 | 400 | tracking_number is required. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| VALUE_INVALID | 4008 | 400 | The value of [field_name] is invalid. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| VALUE_REQUIRED | 4009 | 400 | [field_name] is required. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| SLUG_INVALID | 4010 | 400 | The value of slug is invalid. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| MISSING_OR_INVALID_REQUIRED_FIELD | 4011 | 400 | Missing or invalid value of the required fields for this courier. Besides tracking_number, also required: [field_name] |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| BAD_COURIER | 4012 | 400 | The error message will be one of the following:1. Unable to import shipment as the carrier is not on your approved list for carrier auto-detection. Add the carrier here: https://admin.aftership.com/settings/couriers2. Unable to import shipment as we don&#39;t recognize the carrier from this tracking number.3. Unable to import shipment as the tracking number has an invalid format.4. Unable to import shipment as this carrier is no longer supported.5. Unable to import shipment as the tracking number does not belong to a carrier in that group. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| INACTIVE_RETRACK_NOT_ALLOWED | 4013 | 400 | Retrack is not allowed. You can only retrack an inactive tracking. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| NOTIFICATION_REQUIRED | 4014 | 400 | notification object is required. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| ID_INVALID | 4015 | 400 | The value of id is invalid. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| RETRACK_ONCE_ALLOWED | 4016 | 400 | Retrack is not allowed. You can only retrack each shipment once. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TRACKING_NUMBER_FORMAT_INVALID | 4017 | 400 | The format of tracking_number is invalid. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| API_KEY_INVALID | 401 | 401 | The API Key is invalid. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| REQUEST_NOT_ALLOWED | 403 | 403 | The request is understood, but it has been refused or access is not allowed. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| NOT_FOUND | 404 | 404 | The URI requested is invalid or the resource requested does not exist. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| TOO_MANY_REQUEST | 429 | 429 | You have exceeded the API call rate limit. The default limit is 10 requests per second. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| INTERNAL_ERROR | 500 | 500 | Something went wrong on AfterShip&#39;s end. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| INTERNAL_ERROR | 502 | 502 | Something went wrong on AfterShip&#39;s end. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| INTERNAL_ERROR | 503 | 503 | Something went wrong on AfterShip&#39;s end. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| INTERNAL_ERROR | 504 | 504 | Something went wrong on AfterShip&#39;s end. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |

## Endpoints

The AfterShip SDK has the following resource which are exactly the same as the API endpoints:

- TrackingResource
  - Get trackings
  - Create a tracking
  - Get a tracking by ID
  - Update a tracking by ID
  - Delete a tracking by ID
  - Retrack an expired tracking by ID
  - Mark tracking as completed by ID
- CourierResource
  - Get couriers
  - Detect courier
- CourierConnectionResource
  - Get courier connections
  - Create courier connections
  - Get courier connection by id
  - Update courier connection by id
  - Delete courier connection by id
- EstimatedDeliveryDateResource
  - Prediction for the Estimated Delivery Date
  - Batch prediction for the Estimated Delivery Date

### /trackings
**GET** /trackings

```csharp
    GetTrackingsOptions options = new GetTrackingsOptions();
    GetTrackingsResponse response = client.Tracking.GetTrackings(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**POST** /trackings

```csharp
    CreateTrackingOptions options = new CreateTrackingOptions();
    CreateTrackingRequest createTrackingRequest = new CreateTrackingRequest();
    createTrackingRequest.TrackingNumber = "valid_value";
    options.CreateTrackingRequest = createTrackingRequest;
    CreateTrackingResponse response = client.Tracking.CreateTracking(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**GET** /trackings/{id}

```csharp
    GetTrackingByIdOptions options = new GetTrackingByIdOptions();
    GetTrackingByIdResponse response = client.Tracking.GetTrackingById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**PUT** /trackings/{id}

```csharp
    UpdateTrackingByIdOptions options = new UpdateTrackingByIdOptions();
    UpdateTrackingByIdRequest updateTrackingByIdRequest = new UpdateTrackingByIdRequest();
    options.UpdateTrackingByIdRequest = updateTrackingByIdRequest;
    UpdateTrackingByIdResponse response = client.Tracking.UpdateTrackingById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**DELETE** /trackings/{id}

```csharp
    DeleteTrackingByIdOptions options = new DeleteTrackingByIdOptions();
    DeleteTrackingByIdResponse response = client.Tracking.DeleteTrackingById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**POST** /trackings/{id}/retrack

```csharp
    RetrackTrackingByIdOptions options = new RetrackTrackingByIdOptions();
    RetrackTrackingByIdResponse response = client.Tracking.RetrackTrackingById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**POST** /trackings/{id}/mark-as-completed

```csharp
    MarkTrackingCompletedByIdOptions options = new MarkTrackingCompletedByIdOptions();
    MarkTrackingCompletedByIdRequest markTrackingCompletedByIdRequest = new MarkTrackingCompletedByIdRequest();
    options.MarkTrackingCompletedByIdRequest = markTrackingCompletedByIdRequest;
    MarkTrackingCompletedByIdResponse response = client.Tracking.MarkTrackingCompletedById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

### /couriers
**GET** /couriers

```csharp
    GetCouriersOptions options = new GetCouriersOptions();
    GetCouriersResponse response = client.Courier.GetCouriers(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**POST** /couriers/detect

```csharp
    DetectCourierOptions options = new DetectCourierOptions();
    DetectCourierRequest detectCourierRequest = new DetectCourierRequest();
    detectCourierRequest.TrackingNumber = "valid_value";
    options.DetectCourierRequest = detectCourierRequest;
    DetectCourierResponse response = client.Courier.DetectCourier(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

### /courier-connections
**GET** /courier-connections

```csharp
    GetCourierConnectionsOptions options = new GetCourierConnectionsOptions();
    GetCourierConnectionsResponse response = client.CourierConnection.GetCourierConnections(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**POST** /courier-connections

```csharp
    PostCourierConnectionsOptions options = new PostCourierConnectionsOptions();
    PostCourierConnectionsRequest postCourierConnectionsRequest = new PostCourierConnectionsRequest();
    postCourierConnectionsRequest.CourierSlug = "valid_value";
    postCourierConnectionsRequest.Credentials = new Dictionary<string, string>();
    options.PostCourierConnectionsRequest = postCourierConnectionsRequest;
    PostCourierConnectionsResponse response = client.CourierConnection.PostCourierConnections(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**GET** /courier-connections/{id}

```csharp
    GetCourierConnectionsByIdOptions options = new GetCourierConnectionsByIdOptions();
    GetCourierConnectionsByIdResponse response = client.CourierConnection.GetCourierConnectionsById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**PATCH** /courier-connections/{id}

```csharp
    PutCourierConnectionsByIdOptions options = new PutCourierConnectionsByIdOptions();
    PutCourierConnectionsByIdRequest putCourierConnectionsByIdRequest = new PutCourierConnectionsByIdRequest();
    putCourierConnectionsByIdRequest.Credentials = new Dictionary<string, string>();
    options.PutCourierConnectionsByIdRequest = putCourierConnectionsByIdRequest;
    PutCourierConnectionsByIdResponse response = client.CourierConnection.PutCourierConnectionsById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**DELETE** /courier-connections/{id}

```csharp
    DeleteCourierConnectionsByIdOptions options = new DeleteCourierConnectionsByIdOptions();
    DeleteCourierConnectionsByIdResponse response = client.CourierConnection.DeleteCourierConnectionsById("valid_value",options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

### /estimated-delivery-date
**POST** /estimated-delivery-date/predict

```csharp
    PredictOptions options = new PredictOptions();
    EstimatedDeliveryDateRequest predictRequest = new EstimatedDeliveryDateRequest();
    predictRequest.Slug = "valid_value";
    EstimatedDeliveryDateRequestOriginAddress originAddress = new EstimatedDeliveryDateRequestOriginAddress();
    predictRequest.OriginAddress = originAddress;
    EstimatedDeliveryDateRequestDestinationAddress destinationAddress = new EstimatedDeliveryDateRequestDestinationAddress();
    predictRequest.DestinationAddress = destinationAddress;
    options.PredictRequest = predictRequest;
    PredictResponse response = client.EstimatedDeliveryDate.Predict(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```

**POST** /estimated-delivery-date/predict-batch

```csharp
    PredictBatchOptions options = new PredictBatchOptions();
    PredictBatchRequest predictBatchRequest = new PredictBatchRequest();
    options.PredictBatchRequest = predictBatchRequest;
    PredictBatchResponse response = client.EstimatedDeliveryDate.PredictBatch(options);
    if (response != null)
    {
        Console.WriteLine(response);
    }
```


## Help

If you get stuck, we're here to help:

- [Issue Tracker](https://github.com/AfterShip/tracking-sdk-net/issues) for questions, feature requests, bug reports and general discussion related to this package. Try searching before you create a new issue.
- Contact AfterShip official support via support@aftership.com

## License
Copyright (c) 2025 AfterShip

Licensed under the MIT license.
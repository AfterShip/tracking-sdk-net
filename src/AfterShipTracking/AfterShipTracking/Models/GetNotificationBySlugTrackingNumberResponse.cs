/*
 * This code was auto generated by AfterShip SDK Generator.
 * Do not edit the class manually.
 */
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AfterShipTracking
{
    /// <summary>
    ///
    /// </summary>
    public class GetNotificationBySlugTrackingNumberResponse
    {
        /// <summary>
        ///  Notification Object describes the notification information.
        /// </summary>
        [JsonProperty("notification")]
        public Notification? Notification { get; set; }

        public GetNotificationBySlugTrackingNumberResponse() { }
    }
}

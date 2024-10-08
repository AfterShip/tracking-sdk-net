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
    /// Object describes checkpoint information.
    /// </summary>
    public class  Checkpoint
    {
        /// <summary>
        ///  CreatedAt The date and time of the checkpoint event was added to AfterShip. It uses the format `YYYY-MM-DDTHH:mm:ssZ` for the timezone GMT +0.
        /// </summary>
        [JsonProperty("created_at",NullValueHandling = NullValueHandling.Ignore)]
        public string?  CreatedAt { get; set; }
        /// <summary>
        ///  Slug The unique code of courier for this checkpoint. Get courier slug 
        /// </summary>
        [JsonProperty("slug",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Slug { get; set; }
        /// <summary>
        ///  CheckpointTime The date and time of the checkpoint event, provided by the carrier. It uses the timezone of the checkpoint. The format may differ depending on how the carrier provides it:- YYYY-MM-DDTHH:mm:ss- YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("checkpoint_time",NullValueHandling = NullValueHandling.Ignore)]
        public string?  CheckpointTime { get; set; }
        /// <summary>
        ///  Location Location info provided by carrier
        /// </summary>
        [JsonProperty("location",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Location { get; set; }
        /// <summary>
        ///  City City info provided by carrier
        /// </summary>
        [JsonProperty("city",NullValueHandling = NullValueHandling.Ignore)]
        public string?  City { get; set; }
        /// <summary>
        ///  State State info provided by carrier
        /// </summary>
        [JsonProperty("state",NullValueHandling = NullValueHandling.Ignore)]
        public string?  State { get; set; }
        /// <summary>
        ///  Zip Postal code info provided by carrier
        /// </summary>
        [JsonProperty("zip",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Zip { get; set; }
        /// <summary>
        ///  Coordinate The latitude and longitude coordinates indicate the precise location of the shipments that are currently in transit.
        /// </summary>
        [JsonProperty("coordinate",NullValueHandling = NullValueHandling.Ignore)]
        public CoordinateCheckpoint?  Coordinate { get; set; }
        /// <summary>
        ///  CountryIso3 Country/Region ISO Alpha-3 (three letters) of the checkpoint
        /// </summary>
        [JsonProperty("country_iso3",NullValueHandling = NullValueHandling.Ignore)]
        public string?  CountryIso3 { get; set; }
        /// <summary>
        ///  CountryName Country/Region name of the checkpoint, may also contain other location info.
        /// </summary>
        [JsonProperty("country_name",NullValueHandling = NullValueHandling.Ignore)]
        public string?  CountryName { get; set; }
        /// <summary>
        ///  Message Checkpoint message
        /// </summary>
        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Message { get; set; }
        /// <summary>
        ///  Tag Current status of tracking. (
        /// </summary>
        [JsonProperty("tag",NullValueHandling = NullValueHandling.Ignore)]
        public TagV1?  Tag { get; set; }
        /// <summary>
        ///  Subtag Current subtag of checkpoint. (
        /// </summary>
        [JsonProperty("subtag",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Subtag { get; set; }
        /// <summary>
        ///  SubtagMessage Normalized checkpoint message. (
        /// </summary>
        [JsonProperty("subtag_message",NullValueHandling = NullValueHandling.Ignore)]
        public string?  SubtagMessage { get; set; }
        /// <summary>
        ///  RawTag Checkpoint raw status provided by courier
        /// </summary>
        [JsonProperty("raw_tag",NullValueHandling = NullValueHandling.Ignore)]
        public string?  RawTag { get; set; }
        /// <summary>
        ///  Events The array provides details about specific event(s) that occurred  to a shipment, such as "returned_to_sender". You can find the full list of events and reasons </span>- The events' value for the same checkpoint message is subject to change as we consistently strive to enhance the performance of this feature.
        /// </summary>
        [JsonProperty("events",NullValueHandling = NullValueHandling.Ignore)]
        public EventsCheckpoint? [] Events { get; set; }
        public Checkpoint()
        {
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class  CoordinateCheckpoint
    {
        /// <summary>
        ///  Latitude Represents the latitude.
        /// </summary>
        [JsonProperty("latitude",NullValueHandling = NullValueHandling.Ignore)]
        public double?  Latitude { get; set; }
        /// <summary>
        ///  Longitude Represents the longitude.
        /// </summary>
        [JsonProperty("longitude",NullValueHandling = NullValueHandling.Ignore)]
        public double?  Longitude { get; set; }

        public CoordinateCheckpoint()
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class  ReasonEventsCheckpoint
    {
        /// <summary>
        ///  Code The code of the reason. 
        /// </summary>
        [JsonProperty("code",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Code { get; set; }

        public ReasonEventsCheckpoint()
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class  EventsCheckpoint
    {
        /// <summary>
        ///  Code Represents the event code.
        /// </summary>
        [JsonProperty("code",NullValueHandling = NullValueHandling.Ignore)]
        public string?  Code { get; set; }
        /// <summary>
        ///  Reason Describes the specific reason that led to the event.
        /// </summary>
        [JsonProperty("reason",NullValueHandling = NullValueHandling.Ignore)]
        public ReasonEventsCheckpoint?  Reason { get; set; }

        public EventsCheckpoint()
        {
        }
    }
}

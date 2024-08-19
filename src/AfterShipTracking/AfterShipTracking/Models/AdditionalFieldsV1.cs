/*
 * This code was auto generated by AfterShip SDK Generator.
 * Do not edit the class manually.
 */
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AfterShipTracking
{
    /// <summary>
    /// All available additional fields
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AdditionalFieldsV1
    {
        [EnumMember(Value = "tracking_account_number")]
        TrackingAccountNumber,

        [EnumMember(Value = "tracking_postal_code")]
        TrackingPostalCode,

        [EnumMember(Value = "tracking_ship_date")]
        TrackingShipDate,

        [EnumMember(Value = "tracking_key")]
        TrackingKey,

        [EnumMember(Value = "tracking_origin_country")]
        TrackingOriginCountry,

        [EnumMember(Value = "tracking_destination_country")]
        TrackingDestinationCountry,

        [EnumMember(Value = "tracking_state")]
        TrackingState,
    }
}

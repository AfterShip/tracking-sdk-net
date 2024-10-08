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
    /// Slug group is a group of slugs which belong to same courier. For example, when you inpit &#34;fedex-group&#34; as slug_group, AfterShip will detect the tracking with &#34;fedex-uk&#34;, &#34;fedex-fims&#34;, and other slugs which belong to &#34;fedex&#34;. It cannot be used with slug at the same time. (
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlugGroupV1
    {
        [EnumMember(Value = "amazon-group")]
        AmazonGroup,
        [EnumMember(Value = "fedex-group")]
        FedexGroup,
        [EnumMember(Value = "toll-group")]
        TollGroup,
        [EnumMember(Value = "taqbin-group")]
        TaqbinGroup,
        [EnumMember(Value = "tnt-group")]
        TntGroup,
        [EnumMember(Value = "cj-group")]
        CjGroup,
        [EnumMember(Value = "hermes-group")]
        HermesGroup,
        [EnumMember(Value = "dpd-group")]
        DpdGroup,
        [EnumMember(Value = "gls-group")]
        GlsGroup,
        [EnumMember(Value = "dhl-group")]
        DhlGroup,
        [EnumMember(Value = "fastway-group")]
        FastwayGroup,
        [EnumMember(Value = "asendia-group")]
        AsendiaGroup,
    }
}

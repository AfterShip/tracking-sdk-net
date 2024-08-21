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
    /// Model of all couriers endpoint response
    /// </summary>
    public class  CourierResponseV1
    {
        /// <summary>
        ///  Meta Meta data
        /// </summary>
        [JsonProperty("meta")]
        public MetaV1  Meta { get; set; }
        /// <summary>
        ///  Data 
        /// </summary>
        [JsonProperty("data")]
        public DataCourierResponseV1  Data { get; set; }
        public CourierResponseV1()
        {
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class  DataCourierResponseV1
    {
        /// <summary>
        ///  Total Total count of courier objects
        /// </summary>
        [JsonProperty("total",NullValueHandling = NullValueHandling.Ignore)]
        public int?  Total { get; set; }
        /// <summary>
        ///  Couriers Array of  object.
        /// </summary>
        [JsonProperty("couriers",NullValueHandling = NullValueHandling.Ignore)]
        public Courier? [] Couriers { get; set; }

        public DataCourierResponseV1()
        {
        }
    }
}

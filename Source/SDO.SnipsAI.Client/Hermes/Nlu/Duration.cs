using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Expressions of time that can NOT be positioned in time. This means that starting and finishing points are not defined, neither explicitly nor implicitly. Examples: 
    /// "for 3 years"
    /// "during two hours and five minutes"
    /// </summary>
    [JsonObject]
    public class Duration : GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Duration";

        /// <summary>
        /// "Approximate" or "Exact"
        /// </summary>
        [JsonProperty("precision")]
        public string Precision { get; set; }

        /// <summary>
        /// Years
        /// </summary>
        [JsonProperty("years")]
        public int Years { get; set; }

        /// <summary>
        /// Quarters
        /// </summary>
        [JsonProperty("quarters")]
        public int Quarters { get; set; }

        /// <summary>
        /// Months
        /// </summary>
        [JsonProperty("months")]
        public int Months { get; set; }

        /// <summary>
        /// Weeks
        /// </summary>
        [JsonProperty("weeks")]
        public int Weeks { get; set; }

        /// <summary>
        /// Days
        /// </summary>
        [JsonProperty("days")]
        public int Days { get; set; }

        /// <summary>
        /// Hours
        /// </summary>
        [JsonProperty("hours")]
        public int Hours { get; set; }

        /// <summary>
        /// Minutes
        /// </summary>
        [JsonProperty("minutes")]
        public int Minutes { get; set; }

        /// <summary>
        /// Seconds
        /// </summary>
        [JsonProperty("seconds")]
        public int Seconds { get; set; }
    }
}

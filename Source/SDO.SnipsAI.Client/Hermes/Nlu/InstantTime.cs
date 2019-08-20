using Newtonsoft.Json;
using System;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Expression of time that can be understood as a single time unit (a  cycle, with a specific grain) positioned at a specific moment. Examples:
    ///"now" (grain: second)
    ///"tomorrow at 7:30pm" (grain: minute)
    ///"around seven o'clock" (grain: hour)
    ///"on the day before yesterday" (grain: day)
    ///"next week" (grain: week)
    ///"for January 2019" (grain: month)
    ///"this quarter" (grain: quarter)
    ///"in 2020" (grain: year)
    ///
    ///Resolution in the console:
    ///kind: InstantTime, value: date + time(yyyy-mm-dd hh:mm:ss), grain: Year, Quarter, Month, Week, Day, Hour, Minute, Second; precision: “Exact”, “Approximate" 
    /// </summary>
    [JsonObject]
    public class InstantTime : GenericValueBase<DateTime>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "InstantTime";

        /// <summary>
        /// Year, Quarter, Month, Week, Day, Hour, Minute, Second
        /// </summary>
        [JsonProperty("grain")]
        public string Grain { get; set; }

        /// <summary>
        /// “Exact”, “Approximate"
        /// </summary>
        [JsonProperty("precision")]
        public string Precision { get; set; }
    }

}

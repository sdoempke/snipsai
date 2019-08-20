using Newtonsoft.Json;
using System;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Expression of time consisting of multiple successive time units, and that can be positioned in time. 
    /// Time intervals can be of three kinds:
    /// 
    /// 1. Has a starting point and a finishing point:
    /// "from today 3 pm to tomorrow 8 am" (starting point: today 3 pm, finishing point: tomorrow 8 am)
    /// "from Monday to Wednesday" (starting point: Monday, finishing point: Wednesday)
    /// 
    /// 2. The starting point or the finishing point can be implicit:
    /// "for the next two hours" (starting point [implicit]: now, finishing point: in 2 hours)
    /// "during the last three weeks" (starting point: 3 weeks ago, finishing point[implicit]: now)
    /// 
    /// 3. The starting point or the finishing point can be undefined: 
    /// "until next year" (starting point: undefined, finishing point: next year)
    /// "since last Friday" (starting point: last Friday, finishing point: undefined)
    /// </summary>
    [JsonObject]
    public class TimeInterval: GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "TimeInterval";

        [JsonProperty("from")]
        public DateTime ValueFrom { get; set; }

        [JsonProperty("to")]
        public DateTime ValueTo { get; set; }
    }
}

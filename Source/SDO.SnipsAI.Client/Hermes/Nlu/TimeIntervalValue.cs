using Newtonsoft.Json;
using System;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    //{"kind":"TimeInterval","from":"2019-06-23 07:00:00 +01:00","to":"2019-06-23 12:00:00 +01:00"},"range":{"start":20,"end":35},"entity":"snips/datetime","slotName":"Datum","confidenceScore":1.0}]}

    [JsonObject]
    public class TimeIntervalValue : GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "TimeInterval";

        [JsonProperty("from")]
        public DateTime ValueFrom { get; set; }

        [JsonProperty("to")]
        public DateTime ValueTo { get; set; }
    }

    //{"id":"a90c496e-63f0-44bc-a1c6-03d3b69a1b70","input":"wie wird das wetter heute","intent":{"intentName":"domi:searchWeatherForecast","confidenceScore":0.96426976},"slots":[{"rawValue":"heute","value":{"kind":"InstantTime","value":"2019-05-22 00:00:00 +01:00","grain":"Day","precision":"Exact"},"range":{"start":20,"end":25},"entity":"snips/datetime","slotName":"forecast_start_date_time","confidenceScore":1.0}],"sessionId":"8a98a064-64c8-4ca4-9314-dac0a15a5bed"}
}

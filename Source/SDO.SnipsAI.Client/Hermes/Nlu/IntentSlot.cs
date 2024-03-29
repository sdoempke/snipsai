﻿using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// {"rawValue":"heute","value":{"kind":"InstantTime","value":"2019-05-22 00:00:00 +01:00","grain":"Day","precision":"Exact"},"range":{"start":20,"end":25},"entity":"snips/datetime","slotName":"forecast_start_date_time","confidenceScore":1.0}
    /// </summary>
    [JsonObject]
    public class IntentSlot
    {
        [JsonProperty("slotName")]
        public string Name { get; set; }

        [JsonProperty("confidenceScore")]
        public float Score { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("rawValue")]
        public string RawValue { get; set; }

        [JsonProperty("range")]
        public SlotRange Range { get; set; }

        [JsonProperty("value")]
        public ValueBase Value { get; set; }
    }

    //{"id":"a90c496e-63f0-44bc-a1c6-03d3b69a1b70","input":"wie wird das wetter heute","intent":{"intentName":"domi:searchWeatherForecast","confidenceScore":0.96426976},"slots":[{"rawValue":"heute","value":{"kind":"InstantTime","value":"2019-05-22 00:00:00 +01:00","grain":"Day","precision":"Exact"},"range":{"start":20,"end":25},"entity":"snips/datetime","slotName":"forecast_start_date_time","confidenceScore":1.0}],"sessionId":"8a98a064-64c8-4ca4-9314-dac0a15a5bed"}
}

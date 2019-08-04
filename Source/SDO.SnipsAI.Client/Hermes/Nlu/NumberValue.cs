using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    [JsonObject]
    public class NumberValue : GenericValueBase<double>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Number";
    }

    //{"id":"a90c496e-63f0-44bc-a1c6-03d3b69a1b70","input":"wie wird das wetter heute","intent":{"intentName":"domi:searchWeatherForecast","confidenceScore":0.96426976},"slots":[{"rawValue":"heute","value":{"kind":"InstantTime","value":"2019-05-22 00:00:00 +01:00","grain":"Day","precision":"Exact"},"range":{"start":20,"end":25},"entity":"snips/datetime","slotName":"forecast_start_date_time","confidenceScore":1.0}],"sessionId":"8a98a064-64c8-4ca4-9314-dac0a15a5bed"}
}

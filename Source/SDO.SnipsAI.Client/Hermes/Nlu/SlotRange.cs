using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    [JsonObject]
    public class SlotRange
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }
    }
}

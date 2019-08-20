using Newtonsoft.Json;
using System.Collections.Generic;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    [JsonObject]
    public class NluIntentMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("intent")]
        public IntentClassifierResult Intent { get; set; }

        [JsonProperty("slots")]
        public List<IntentSlot> Slots { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}

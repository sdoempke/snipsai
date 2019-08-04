using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDO.SnipsAI.Client.Hermes.Tts
{
    [JsonObject]
    public class SayFinishedMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace SDO.SnipsAI.Client.Hermes.Tts
{
    /// <summary>
    /// </summary>
    [JsonObject]
    public class SayMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}

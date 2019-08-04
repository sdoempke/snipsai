using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// This message is sent by the Dialogue Manager when a new session is started, either following a wakeword or programmatically.
    /// 
    /// {"sessionId":"0dc79bbd-8660-4df3-b272-16e61cb48685","customData":null,"siteId":"default","reactivatedFromSessionId":null}
    /// </summary>
    [JsonObject]
    public class SessionStartedMessage
    {
        /// <summary>
        /// Site where the user interaction is taking place.
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// Session identifier that was started.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("reactivatedFromSessionId")]
        public string ReactivedFromSessionId { get; set; }

        /// <summary>
        ///Custom data provided in the Start Session.
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }
    }
}

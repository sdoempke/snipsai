using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// This message is sent by the Dialogue Manager when it receives a Start Session message and the corresponding site is busy. 
    /// Only Start Session messages with a notification initialisation or an action initialisation with the canBeEnqueued flag set to true can be enqueued. 
    /// When the site is free again, this session will be started.
    /// 
    /// You should subscribe tohermes/dialogueManager/sessionQueued.
    /// </summary>
    [JsonObject]
    public class SessionQueuedMessage
    {
        /// <summary>
        /// Session identifier that was enqueued.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// Site where the user interaction will take place.
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// (Optional) Custom data provided in the Start Session.
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }
    }
}

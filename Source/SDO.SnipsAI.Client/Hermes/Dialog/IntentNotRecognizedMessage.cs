using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{

    /// <summary>
    /// This message is sent by the dialogue manager when it failed to recognize 
    /// and intent AND you requested the dialogue manager to notify you of such 
    /// events using the sendIntentNotRecognized flag in the last Start Session or Continue Session
    /// 
    /// You should subscribe to hermes/dialogueManager/intentNotRecognized.
    /// </summary>
    [JsonObject]
    public class IntentNotRecognizedMessage
    {
        /// <summary>
        ///  Site where the user interaction took place.
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// Session identifier of the session that generated this intent not recognized event.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// (Optional) Custom data provided in the Start Session.
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }

        /// <summary>
        /// (Optional) The input, if any that generated this event.
        /// </summary>
        [JsonProperty("input")]
        public string Input { get; set; }
    }
}

using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// You can send this message to programmatically initiate a new session. 
    /// The Dialogue Manager will start the session by asking the TTS to say the text (if any) and wait for the answer of the end user.
    /// 
    /// You should publish to hermes/dialogueManager/startSession.
    /// </summary>
    [JsonObject]
    public class StartSessionMessage
    {
        /// <summary>
        /// (Optional) Site where to start the session. 
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// (Optional) Additional information that can be provided by the handler. Each message related to the new session - sent by the Dialogue Manager - will contain this data
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }

        /// <summary>
        /// Session initialization description: Action or Notification.
        /// </summary>
        [JsonProperty("init")]
        public StartSessionInitialization Initialization { get; set; }

    }

    /// <summary>
    /// Base class for Session initialization description: Action or Notification.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(StartSessionAction), "action")]
    [JsonSubtypes.KnownSubType(typeof(StartSessionNotification), "notification")]
    [JsonObject]
    public abstract class StartSessionInitialization
    {
        [JsonProperty("type")]
        public virtual string Type { get; }
    }

    /// <summary>
    /// Use this type when you need the end user to respond
    /// </summary>
    [JsonObject]
    public class StartSessionAction : StartSessionInitialization
    {
        [JsonProperty("type")]
        public override string Type { get; } = "action";

        /// <summary>
        /// (Optional) Text that the TTS should say at the beginning of the session.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// (Optional) if true, the session will start when there is no pending one on this siteId, if false, the session is just dropped if there is running one.
        /// </summary>
        [JsonProperty("canBeEnqueued")]
        public bool? CanBeEnqueued { get; set; }

        /// <summary>
        /// (Optional)  A list of intents names to restrict the NLU resolution on the first query.
        /// </summary>
        [JsonProperty("intentFilter")]
        public string[] FilteredIntents { get; set; }

        /// <summary>
        /// (Optional) Indicates whether the dialogue manager should handle non recognized intents by itself or sent them as an Intent Not Recognized for the client to handle. 
        /// This setting applies only to the next conversation turn.The default value is false (and the dialogue manager will handle non recognized intents by itself)
        /// </summary>
        [JsonProperty("sendIntentNotRecognized")]
        public bool? SendIntentNotRecognized { get; set; }
    }

    /// <summary>
    /// Use this type when you only want to inform the user of something without expecting a response.
    /// </summary>
    [JsonObject]
    public class StartSessionNotification : StartSessionInitialization
    {
        [JsonProperty("type")]
        public override string Type { get; } = "notification";

        /// <summary>
        /// Text the TTS should say
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
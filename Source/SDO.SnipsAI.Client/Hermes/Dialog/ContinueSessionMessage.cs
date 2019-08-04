using Newtonsoft.Json;
using System.Collections.Generic;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// You should send this after receiving received an Intent when you want to continue the session for example to ask additional information to the end user.
    /// Be sure to use the same sessionId as the one in the Intent message.
    /// 
    /// You should publish to hermes/dialogueManager/continueSession.
    /// </summary>
    [JsonObject]
    public class ContinueSessionMessage
    {
        /// <summary>
        /// Identifier of the session to continue.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// The text the TTS should say to start this additional request of the session.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// A list of intents names to restrict the NLU resolution on the answer of this query.
        /// If this contains unknown intent names, the NLU will post an error message and the session will be closed.
        /// </summary>
        [JsonProperty("intentFilter")]
        public string[] FilteredIntents { get; set; }

        /// <summary>
        /// (Optional) An update to the session's custom data. If not provided, the custom data will stay the same.
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }

        /// <summary>
        /// (Optional) Indicates whether the dialogue manager should handle non recognized intents by itself or sent them as an Intent Not Recognized for the client to handle. This setting applies only to the next conversation turn.The default value is false (and the dialogue manager will handle non recognized intents by itself).
        /// </summary>
        [JsonProperty("sendIntentNotRecognized")]
        public bool? SendIntentNotRecognized { get; set; }

        /// <summary>
        /// (Optional) Requires intentFilter to contain a single value - If set, the dialogue engine will not run the the intent classification on the user response and go straight to slot filling, assuming the intent is the one passed in the intentFilter, and searching the value of the given slot
        /// </summary>
        [JsonProperty("slot")]
        public string Slot { get; set; }
    }
}

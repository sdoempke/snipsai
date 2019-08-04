using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// This message is sent by the Dialogue Manager when a session is ended.
    /// 
    /// {"sessionId":"0dc79bbd-8660-4df3-b272-16e61cb48685","customData":null,"termination":{"reason":"intentNotRecognized"},"siteId":"default"}
    /// </summary>
    [JsonObject]
    public class SessionEndedMessage
    {
        /// <summary>
        /// Site where the user interaction took place.
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// Session identifier of the ended session.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// Custom data provided in the Start Session or a Continue Session.
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }

        /// <summary>
        /// Structured description of why the session has been ended.
        /// </summary>
        [JsonProperty("termination")]
        public SessionTermination Termination { get; set; }
    }

    /// <summary>
    /// Structured description of why the session has been ended.
    /// {"reason":"intentNotRecognized"}
    /// </summary>
    [JsonObject]
    public class SessionTermination
    {
        /// <summary>
        /// Reason for the termination
        /// </summary>
        [JsonProperty("reason")]
        public SessionTerminationReason Reason { get; set; }
    }

    /// <summary>
    /// Enum with the reason for the termination of a session
    /// </summary>
    public enum SessionTerminationReason
    {
        /// <summary>
        /// the session ended as expected (a endSession message was received).
        /// </summary>
        [EnumMember(Value = "nominal")]
        Nominal,

        /// <summary>
        /// the session aborted by the user.
        /// </summary>
        [EnumMember(Value = "abortedByUser")]
        AbortedByUser,

        /// <summary>
        /// the session ended because no intent was successfully detected.
        /// </summary>
        [EnumMember(Value = "intentNotRecognized")]
        IntentNotRecognized,

        /// <summary>
        /// The session timed out because no response from one of the components or no Continue Session or End Sessionfrom the handler code was received in a timely manner
        /// </summary>
        [EnumMember(Value = "timeout")]
        Timeout,

        /// <summary>
        /// The session failed with an error.
        /// </summary>
        [EnumMember(Value = "error")]
        Error,
    }
}

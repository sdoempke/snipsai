using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// You should send this after receiving received an Intent when you want to end the session.
    /// Be sure to use the same sessionId as the one in the Intent message.
    /// 
    /// You should publish to hermes/dialogueManager/endSession.
    /// </summary>
    [JsonObject]
    public class EndSessionMessage
    {
        /// <summary>
        /// Identifier of the session to end.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// (Optinal)  The text the TTS should say to end the session.
        /// If the text is null, the Dialog Manager will immediately send a Session Ended after receiving this message, otherwise, the Session Ended will be sent after the text is said.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}

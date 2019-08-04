using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// The interface for the API of the dialog manager of Snips Ai
    /// </summary>
    public interface IDialogApi
    {
        /// <summary>
        /// Is sent by the Dialogue Manager when an intent has been detected.
        /// </summary>
        IDialogOnIntentDetectedHandler OnIntentDetectedHandler { get; set; }

        /// <summary>
        /// This message is sent by the dialogue manager when it failed to recognize and intent AND you requested the dialogue manager
        /// to notify you of such events using the sendIntentNotRecognized flag in the last Start Session or Continue Session
        /// </summary>
        IDialogOnIntentNotRecognizedHandler OnIntentNotRecognizedHandler { get; set; }

        /// <summary>
        /// This message is sent by the Dialogue Manager when a new session is started, either following a wakeword or programmatically.
        /// </summary>
        IDialogOnSessionStartedHandler OnSessionStartedHandler { get; set; }

        /// <summary>
        /// This message is sent by the Dialogue Manager when it receives a Start Session message and the corresponding site is busy. 
        /// Only Start Session messages with a notification initialisation or an action initialisation with the canBeEnqueued flag set to true can be enqueued. 
        /// When the site is free again, this session will be started.
        /// </summary>
        IDialogOnSessionQueuedHandler OnSessionQueuedHandler { get; set; }

        /// <summary>
        /// This message is sent by the Dialogue Manager when a session is ended.
        /// </summary>
        IDialogOnSessionEndedHandler OnSessionEndedHandler { get; set; }

        /// <summary>
        /// You can send this message to programmatically initiate a new session. The Dialogue Manager will start the session by asking the TTS to say the text (if any) and wait for the answer of the end user.
        /// </summary>
        /// <returns></returns>
        Task StartSessionAsync();

        /// <summary>
        /// You can send this message to programmatically initiate a new session. The Dialogue Manager will start the session by asking the TTS to say the text (if any) and wait for the answer of the end user.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task StartSessionAsync(StartSessionMessage message);

        /// <summary>
        /// You can send this message to programmatically initiate a new session. The Dialogue Manager will start the session by asking the TTS to say the text (if any) and wait for the answer of the end user.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="canBeEnqueued"></param>
        /// <param name="sendIntentNotRecognized"></param>
        /// <param name="customData"></param>
        /// <param name="siteId"></param>
        /// <param name="allowedIntents"></param>
        /// <returns></returns>
        Task StartSessionAsync(string text = null, bool canBeEnqueued = true, bool sendIntentNotRecognized = false, string customData = null, string siteId = null, params string[] allowedIntents);

        /// <summary>
        /// You should send this after receiving received an Intent when you want to continue the session for example to ask additional information to the end user.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task ContinueSessionAsync(ContinueSessionMessage message);

        /// <summary>
        /// You should send this after receiving received an Intent when you want to continue the session for example to ask additional information to the end user.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="text"></param>
        /// <param name="sendIntentNotRecognized"></param>
        /// <param name="customData"></param>
        /// <param name="slot"></param>
        /// <param name="allowedIntents"></param>
        /// <returns></returns>
        Task ContinueSessionAsync(string sessionId, string text, bool sendIntentNotRecognized = false, string customData = null, string slot = null, params string[] allowedIntents);

        /// <summary>
        /// You should send this after receiving received an Intent when you want to end the session.
        /// Be sure to use the same sessionId as the one in the Intent message.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        Task EndSessionAsync(string sessionId, string text);

        /// <summary>
        /// You should send this after receiving received an Intent when you want to end the session.
        /// Be sure to use the same sessionId as the one in the Intent message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task EndSessionAsync(EndSessionMessage message);
    }

    public interface IDialogOnIntentDetectedHandler
    {
        Task HandleOnIntentDetectedAsync(IntentMessage message);
    }

    public interface IDialogOnIntentNotRecognizedHandler
    {
        Task HandleOnIntentNotRecognizedAsync(IntentNotRecognizedMessage message);
    }

    public interface IDialogOnSessionQueuedHandler
    {
        Task HandleOnSessionQueuedAsync(SessionQueuedMessage message);
    }

    public interface IDialogOnSessionStartedHandler
    {
        Task HandleOnSessionStartedAsync(SessionStartedMessage message);
    }

    public interface IDialogOnSessionEndedHandler
    {
        Task HandleOnSessionEndedAsync(SessionEndedMessage message);
    }
}

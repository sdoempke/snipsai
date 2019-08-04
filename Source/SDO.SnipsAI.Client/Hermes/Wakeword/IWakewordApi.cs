using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Hermes.Wakeword
{
    public interface IWakewordApi
    {
        /// <summary>
        /// This will activate the Wake Word component of the Snips Platform.
        /// </summary>
        /// <param name="siteId">The id of the site where the wake word detector should be turned on</param>
        /// <returns></returns>
        Task ToggleWakewordOnAsync(string siteId);

        /// <summary>
        /// This will deactivate the Wake Word component of the Snips Platform. Consequently, nothing will be triggered when a wake word is pronounced.
        /// </summary>
        /// <param name="siteId">The id of the site where the wake word detector should be turned off</param>
        /// <param name="sessionId">The id of the session, if there is an active session</param>
        /// <returns></returns>
        Task ToggleWakewordOffAsync(string siteId, string sessionId = null);

        /// <summary>
        /// Sends a wakeword detection.
        /// This is for 3rd party wakeword detection engines
        /// </summary>
        /// <param name="wakewordId">Id of the wakeword</param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendWakewordDetectedAsync(string wakewordId, WakewordDetectedMessage message);
    }
}

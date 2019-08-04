using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Hermes.Asr
{
    /// <summary>
    /// The ASR component receives raw audio input and transcribes it into text.
    /// </summary>
    public interface IAsrApi
    {
        /// <summary>
        /// This will activate the ASR component of the Snips Platform.
        /// </summary>
        /// <returns></returns>
        Task ToggleAsrOnAsync();

        /// <summary>
        /// This will deactivate the ASR component of the Snips Platform.
        /// </summary>
        /// <returns></returns>
        Task ToggleAsrOffAsync();

        /// <summary>
        /// This will explicitly tell the ASR component to start listening for voice input.
        /// </summary>
        /// <param name="siteId">The id of the site where the ASR should start listening</param>
        /// <param name="sessionId">The id of the session, if there is an active session</param>
        /// <returns></returns>
        Task StartAsrToListen(string siteId, string sessionId = null);

        /// <summary>
        /// This will explicitly tell the ASR component to stop listening for voice input.
        /// </summary>
        /// <param name="siteId">The id of the site where the ASR should stop listening</param>
        /// <param name="sessionId">The id of the session, if there is an active session</param>
        /// <returns></returns>
        Task StopAsrToListen(string siteId, string sessionId = null);
    }
}

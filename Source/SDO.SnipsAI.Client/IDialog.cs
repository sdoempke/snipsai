using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client
{
    /// <summary>
    /// Interface for a dialog in snips
    /// It is implemented by classes handling a dialog started with a specific intent
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// What is the name of the initial intent that is handled with this dialog?
        /// </summary>
        string InitialIntentName { get; }

        /// <summary>
        /// Is called when the handler is registered
        /// Injects the message sender
        /// </summary>
        /// <param name="voiceMessageSender"></param>
        void OnRegistration(ISnipsApi voiceMessageSender);

        /// <summary>
        /// Is called when the handler is unregistered
        /// </summary>
        void OnUnregistration();

        /// <summary>
        /// Is called when a indent is found  
        /// </summary>
        /// <param name="intend">Received intent</param>
        /// <param name="session">Session</param>
        /// <returns>Task as this is a async method</returns>
        Task OnIntentAsync(IntentMessage intend, Session session);

        /// <summary>
        /// Is called when a session related to this dialog has ended
        /// </summary>
        /// <returns>Task as this is a async method</returns>
        Task OnSessionEndedAsync(SessionTermination terminationReason);
    }
}

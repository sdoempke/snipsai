using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client
{
    public interface IDialog
    {
        /// <summary>
        /// What the name of the initial intent the is handled?
        /// </summary>
        string InitialIntendName { get; }

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
        /// <param name="intend"></param>
        /// <param name="session"></param>
        Task OnIntentAsync(IntentMessage intend, Session session);
    }
}

using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Demo
{
    /// <summary>
    /// This is a simple demo Dialog
    /// </summary>
    public class TestDialog : IDialog
    {
        /// <summary>
        /// snips api
        /// </summary>
        private ISnipsApi _snipsApi;

        /// <summary>
        /// Name of the initial intent starting the dialog
        /// Replace this with your intent
        /// </summary>
        public string InitialIntentName => "sdoempke:Greeting";

        /// <summary>
        /// Called when the intent has been recognized
        /// </summary>
        /// <param name="intent"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public async Task OnIntentAsync(IntentMessage intent, Session session)
        {
            //Check the Slots in intent

            //Finish the session
            await _snipsApi.EndSessionAsync(intent.SessionId, "Test is Done!");
        }

        /// <summary>
        /// Called when the Dialog is registered
        /// </summary>
        /// <param name="snipsApi">snips api</param>
        public void OnRegistration(ISnipsApi snipsApi)
        {
            _snipsApi = snipsApi;
        }

        /// <summary>
        /// Called when the Dialog is unregistered
        /// </summary>
        public void OnUnregistration()
        {
        }
    }
}
using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client
{
    /// <summary>
    /// Class representing a session in snips
    /// It is used to:
    ///    1) Manage active Sessions
    ///    2) Collected data of a active sessions (like IntentMessages)
    ///    3) Store custom data at the session for (Tag)
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Id of the session
        /// </summary>
        public string Id { get; private set; }
    
        /// <summary>
        /// Id of the site which has started the session
        /// </summary>
        public string SiteId { get; private set; }

        /// <summary>
        /// When was it started?
        /// </summary>
        public DateTime Started { get; private set; }

        /// <summary>
        /// List of all intent messages of this session
        /// </summary>
        public List<IntentMessage> IntentMessages { get; private set; } = new List<IntentMessage>();

        /// <summary>
        /// Dialog belonging to this session 
        /// </summary>
        public IDialog Dialog { get; private set; }

        /// <summary>
        /// What slots have been found yet?
        /// This must be filled manually by the Dialog if if manages missing slots by its own
        /// </summary>
        public List<Hermes.Nlu.IntentSlot> FoundSlots { get; private set; } = new List<Hermes.Nlu.IntentSlot>();

        /// <summary>
        /// To storage any kind of object at the session 
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of the site</param>
        /// <param name="siteId">Site which as started the session</param>
        public Session(string id, string siteId)
        {
            Id = id;
            SiteId = siteId;
            Started = DateTime.Now;
        }

        /// <summary>
        /// Called when the session has ended
        /// </summary>
        /// <param name="terminationReason">Termination reson</param>
        internal async Task OnEndedAsync(SessionTermination terminationReason)
        {
            if(Dialog != null)
            {
                await Dialog.OnSessionEndedAsync(terminationReason).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Set the dialog for this session
        /// </summary>
        /// <param name="dialog"></param>
        internal void SetDialog(IDialog dialog)
        {
            Dialog = dialog;
        }
    }
}

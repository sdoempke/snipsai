using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;

namespace SDO.SnipsAI.Client
{
    /// <summary>
    /// Class representing a session in snips
    /// It is used to:
    ///    1) Manage active Sessions
    ///    2) Collected data of a active sessions
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Id of the session
        /// </summary>
        public string Id { get; private set; }
    
        /// <summary>
        /// Id of the site
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
        /// </summary>
        public List<Hermes.Nlu.IntentSlot> FoundSlots { get; private set; } = new List<Hermes.Nlu.IntentSlot>();

        public Session(string id, string siteId)
        {
            Id = id;
            SiteId = siteId;
            Started = DateTime.Now;
        }

        /// <summary>
        /// Called when the session has ended
        /// </summary>
        /// <param name="termination">Termination reson</param>
        internal void OnEnded(SessionTermination termination)
        {
            
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

using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;

namespace SDO.SnipsAI.Client
{
    /// <summary>
    /// Class for a session in snips
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
        /// 
        /// </summary>
        /// <param name="termination">Termination reson</param>
        internal void OnEnded(SessionTermination termination)
        {
            
        }

        internal void SetDialog(IDialog dialog)
        {
            Dialog = dialog;
        }
    }
}

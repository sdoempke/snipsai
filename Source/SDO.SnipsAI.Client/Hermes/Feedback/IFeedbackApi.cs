using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Hermes.Feedback
{
    public interface IFeedbackApi
    {
        Task ToggleFeedbackSoundOnAsync(string siteId);

        Task ToggleFeedbackSoundOffAsync(string siteId);
    }
}

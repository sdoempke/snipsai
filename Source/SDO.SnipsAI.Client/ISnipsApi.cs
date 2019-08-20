using SDO.SnipsAI.Client.Hermes.Asr;
using SDO.SnipsAI.Client.Hermes.AudioServer;
using SDO.SnipsAI.Client.Hermes.Dialog;
using SDO.SnipsAI.Client.Hermes.Feedback;
using SDO.SnipsAI.Client.Hermes.Nlu;
using SDO.SnipsAI.Client.Hermes.Tts;
using SDO.SnipsAI.Client.Hermes.Wakeword;

namespace SDO.SnipsAI.Client
{
    /// <summary>
    /// Collection interface for the snips.ai api 
    /// </summary>
    public interface ISnipsApi : IDialogApi, ITtsApi, INluApi, IAudioServerApi, IFeedbackApi, IWakewordApi, IAsrApi
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Hermes.Tts
{
    public interface ITtsApi
    {
        /// <summary>
        /// Called when TTS has finished speaking some text
        /// </summary>
        ITtsOnSayFinishedHandler OnSayFinishedHandler { get; set; }

        Task SendSayMessageAsync(SayMessage message);
    }

    public interface ITtsOnSayFinishedHandler
    {
        Task HandleOnSayFinishedAsync(SayFinishedMessage message);
    }
}

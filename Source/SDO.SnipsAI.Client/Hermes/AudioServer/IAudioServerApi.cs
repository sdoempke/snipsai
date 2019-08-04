using SDO.SnipsAI.Client.Hermes.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Hermes.AudioServer
{
    public interface IAudioServerApi
    {
        /// <summary>
        ///
        /// </summary>
        IAudioServerOnFrameReceivedHandler OnFrameReceivedHandler { get; set; }
    }

    public interface IAudioServerOnFrameReceivedHandler
    {
        Task HandleOnFrameReceviedAsync(string site, byte[] data);
    }
}

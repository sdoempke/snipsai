using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Song name
    /// </summary>
    [JsonObject]
    public class MusicTrack : GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "MusicTrack";
    }
}

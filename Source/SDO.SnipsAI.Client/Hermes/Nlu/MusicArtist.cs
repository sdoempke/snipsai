using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Artist or band name
    /// </summary>
    [JsonObject]
    public class MusicArtist : GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "MusicArtist";
    }
}

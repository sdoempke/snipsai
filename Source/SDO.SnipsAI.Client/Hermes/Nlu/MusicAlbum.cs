using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Album name
    /// </summary>
    [JsonObject]
    public class MusicAlbum : GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "MusicAlbum";
    }
}

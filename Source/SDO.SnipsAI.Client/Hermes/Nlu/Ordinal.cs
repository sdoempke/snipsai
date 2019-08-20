using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Ordinal number
    /// Supported range for en, fr, de, ja: 1st to 1000th
    /// Supported range for es: 1st to 20th
    /// </summary>
    [JsonObject]
    public class Ordinal : GenericValueBase<long>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Ordinal";
    }
}

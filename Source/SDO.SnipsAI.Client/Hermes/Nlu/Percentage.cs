using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Percentage
    /// </summary>
    [JsonObject]
    public class Percentage : GenericValueBase<float>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Percentage";
    }
}

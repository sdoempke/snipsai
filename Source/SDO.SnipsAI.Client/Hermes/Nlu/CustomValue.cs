using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    [JsonObject]
    public class CustomValue : GenericValueBase<string>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Custom";
    }
}

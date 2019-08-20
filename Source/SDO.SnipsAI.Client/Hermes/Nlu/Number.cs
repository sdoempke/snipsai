using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Integer number, positive or negative
    /// Supported range:  -999.999.999.999 to 999.999.999.999
    /// </summary>
    [JsonObject]
    public class Number : GenericValueBase<double>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Number";
    }
}

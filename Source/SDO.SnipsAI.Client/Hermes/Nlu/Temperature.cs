using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    /// <summary>
    /// Temperature
    /// 
    /// Positive or negative expressed in degrees, Celsius, Kelvin or Fahrenheit
    /// </summary>
    [JsonObject]
    public class Temperature : GenericValueBase<float>
    {
        [JsonProperty("kind")]
        public override string Kind { get; } = "Temperature";

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}

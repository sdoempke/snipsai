using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Wakeword
{
    /// <summary>
    /// This message will be sent by the Snips Platform when the Wake Word component has detected that a specific wake word has been uttered.
    /// </summary>
    [JsonObject]
    public class WakewordDetectedMessage
    {
        /// <summary>
        /// The id of the site where the wake word detector should be turned on
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// The id of the model that triggered the wake word
        /// </summary>
        [JsonProperty("modelId")]
        public string ModelId { get; set; }

        /// <summary>
        /// The version of the model
        /// </summary>
        [JsonProperty("modelVersion")]
        public string ModelVersion { get; set; }

        /// <summary>
        /// The type of the model.Possible values: universal or personal
        /// </summary>
        [JsonProperty("modelType")]
        public string ModelType { get; set; }

        /// <summary>
        /// The sensitivity configured in the model at the time of the detection
        /// </summary>
        [JsonProperty("currentSensitivity")]
        public float CurrentSensitivity { get; set; }
    }
}

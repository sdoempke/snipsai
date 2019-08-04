using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDO.SnipsAI.Client.Hermes.Dialog
{
    /// <summary>
    /// This is the main message the handler code should subscribe to. It is sent by the Dialogue Manager when an intent has been detected.
    /// Note that it is the handler's responsibility to inform the Dialogue Manager of what it should do with the current session by sending 
    /// either a Continue Session or an End Session with the current sessionId
    /// 
    /// You should subscribe tohermes/intent/<intentName>.
    /// Replace <intentName> by the name of the intent you want to handle.You can use the MQTT wildcard # to receive all intents.
    /// 
    /// {"sessionId":"eaa34a9f-ec74-4670-a1bd-420682277e7a","customData":null,"siteId":"default","input":"lade teil fünf eins vier in platz a zwei","asrTokens":[[{"value":"lade","confidence":1.0,"rangeStart":0,"rangeEnd":4,"time":{"start":0.0,"end":0.57}},{"value":"teil","confidence":1.0,"rangeStart":5,"rangeEnd":9,"time":{"start":0.57,"end":0.87}},{"value":"fünf","confidence":0.95918596,"rangeStart":10,"rangeEnd":14,"time":{"start":0.87,"end":1.071429}},{"value":"eins","confidence":0.93433195,"rangeStart":15,"rangeEnd":19,"time":{"start":1.0809615,"end":1.4694571}},{"value":"vier","confidence":0.9656361,"rangeStart":20,"rangeEnd":24,"time":{"start":1.4694571,"end":1.7017527}},{"value":"in","confidence":0.96647334,"rangeStart":25,"rangeEnd":27,"time":{"start":1.7017527,"end":1.7470657}},{"value":"platz","confidence":1.0,"rangeStart":28,"rangeEnd":33,"time":{"start":1.7470657,"end":2.19}},{"value":"a","confidence":1.0,"rangeStart":34,"rangeEnd":35,"time":{"start":2.19,"end":2.22}},{"value":"zwei","confidence":1.0,"rangeStart":36,"rangeEnd":40,"time":{"start":2.22,"end":3.36}}]],"asrConfidence":0.98034424,"intent":{"intentName":"sdoempke:LadeTeilInContainerAnLadeplatz","confidenceScore":0.7294636},"slots":[{"rawValue":"fünf","value":{"kind":"Custom","value":"5"},"range":{"start":10,"end":14},"entity":"TeileCodes","slotName":"TeileCode","confidenceScore":0.95918596},{"rawValue":"eins","value":{"kind":"Custom","value":"1"},"range":{"start":15,"end":19},"entity":"TeileCodes","slotName":"TeileCode","confidenceScore":0.93433195},{"rawValue":"vier","value":{"kind":"Custom","value":"4"},"range":{"start":20,"end":24},"entity":"TeileCodes","slotName":"TeileCode","confidenceScore":0.9656361},{"rawValue":"a zwei","value":{"kind":"Custom","value":"A2"},"range":{"start":34,"end":40},"entity":"Ladeplatztypen","slotName":"LadeplatzCode","confidenceScore":1.0}]}
    /// </summary>
    [JsonObject]
    public class IntentMessage
    {
        /// <summary>
        /// Session of the intent detection. The client code must use it to continue or end the session.
        /// </summary>
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// (Optional) custom data provided in the Start Session or a Continue Session.
        /// </summary>
        [JsonProperty("customData")]
        public string CustomData { get; set; }

        /// <summary>
        /// Site where the user interaction took place.
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// The user input that has generated this intent.
        /// </summary>
        [JsonProperty("input")]
        public string Input { get; set; }

        /// <summary>
        /// Structured description of the intent classification
        /// </summary>
        [JsonProperty("intent")]
        public Nlu.IntentClassifierResult Intent { get; set; }

        /// <summary>
        /// Structured description of the detected slots for this intent if any
        /// </summary>
        [JsonProperty("slots")]
        public List<Nlu.IntentSlot> Slots { get; set; }

        /// <summary>
        /// (Optional) Structured description of the tokens the ASR captured on for this intent. The first level of arrays represents each invocation of the ASR, the second one are the tokens captured, see ASR Token below. Note that this is not mapped on Android and iOS yet
        /// </summary>
        ///[JsonProperty("asrTokens")]
        ///public List<string> AsrTokens { get; set; }

        /// <summary>
        /// (Optional) ASR confidence score between 0 and 1, 1 being sure.
        /// </summary>
        [JsonProperty("asrConfidence")]
        public float? AsrConfidence { get; set; }
    }
}

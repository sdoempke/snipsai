using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class InstantTimeTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"InstantTime\", \"value\": \"2017-06-13 07:00:00+02:00\", \"grain\": \"Hour\", \"precision\": \"Exact\" }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as InstantTime;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual(new DateTime(2017, 06, 13, 07, 00, 00, DateTimeKind.Utc), parsedInstance.Value);
            Assert.AreEqual("Hour", parsedInstance.Grain);
            Assert.AreEqual("Exact", parsedInstance.Precision);
        }
    }
}

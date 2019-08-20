using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class PercentageTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Percentage\", \"value\": 25.0 }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Percentage;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(25f, parsedInstance.Value);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class OrdinalTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Ordinal\", \"value\": 2 }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Ordinal;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual(2, parsedInstance.Value);
        }
    }
}

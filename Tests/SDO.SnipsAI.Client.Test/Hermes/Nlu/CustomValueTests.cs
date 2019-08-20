using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class CustomValueTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Custom\", \"value\": \"Test123\" }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as CustomValue;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual("Test123", parsedInstance.Value);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Number\", \"value\": 22.0 }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Number;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual(22.0d, parsedInstance.Value);
        }
    }
}

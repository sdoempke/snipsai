using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class TempartureTests
    {
        [TestMethod]
        public void Deserialize1()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Temperature\", \"value\": 70.0, \"unit\": \"kelvin\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Temperature;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(70.0d, parsedInstance.Value);
            Assert.AreEqual("kelvin", parsedInstance.Unit);
        }

        [TestMethod]
        public void Deserialize2()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Temperature\", \"value\": 1, \"unit\": \"degree\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Temperature;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(1d, parsedInstance.Value);
            Assert.AreEqual("degree", parsedInstance.Unit);
        }

        [TestMethod]
        public void Deserialize3()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Temperature\", \"value\": -3, \"unit\": \"celsius\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Temperature;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(-3d, parsedInstance.Value);
            Assert.AreEqual("celsius", parsedInstance.Unit);
        }
    }
}

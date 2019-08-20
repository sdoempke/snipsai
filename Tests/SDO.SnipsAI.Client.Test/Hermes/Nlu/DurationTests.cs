using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class DurationTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"Duration\", \"years\": 1, \"quarters\": 2, \"months\": 3, \"weeks\": 4, \"days\": 5, \"hours\": 6, \"minutes\": 7, \"seconds\": 8, \"precision\": \"Exact\" }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as Duration;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual(1, parsedInstance.Years);
            Assert.AreEqual(2, parsedInstance.Quarters);
            Assert.AreEqual(3, parsedInstance.Months);
            Assert.AreEqual(4, parsedInstance.Weeks);
            Assert.AreEqual(5, parsedInstance.Days);
            Assert.AreEqual(6, parsedInstance.Hours);
            Assert.AreEqual(7, parsedInstance.Minutes);
            Assert.AreEqual(8, parsedInstance.Seconds);
            Assert.AreEqual("Exact", parsedInstance.Precision);
        }
    }
}

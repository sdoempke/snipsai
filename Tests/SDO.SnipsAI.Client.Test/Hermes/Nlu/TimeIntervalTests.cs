using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class TimeIntervalTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{\"kind\": \"TimeInterval\", \"from\": \"2017-06-07 17:00:00+02:00\", \"to\": \"2017-06-08 18:00:00+02:00\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as TimeInterval;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual(new DateTime(2017, 06, 07, 17, 00, 00, DateTimeKind.Utc), parsedInstance.ValueFrom);
            Assert.AreEqual(new DateTime(2017, 06, 08, 18, 00, 00, DateTimeKind.Utc), parsedInstance.ValueTo);
        }
    }
}

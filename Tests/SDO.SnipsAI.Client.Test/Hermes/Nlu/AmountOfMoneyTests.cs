using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class AmountOfMoneyTests
    {
        [TestMethod]
        public void Deserialize1()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"AmountOfMoney\", \"value\":10.05, \"precision\": \"Approximate\", \"unit\": \"€\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as AmountOfMoney;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(10.05, Math.Round(parsedInstance.Value, 2));
            Assert.AreEqual("Approximate", parsedInstance.Precision);
            Assert.AreEqual("€", parsedInstance.Unit);
        }

        [TestMethod]
        public void Deserialize2()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"AmountOfMoney\", \"value\":1, \"precision\": \"Exact\", \"unit\": \"$\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as AmountOfMoney;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(1f, parsedInstance.Value);
            Assert.AreEqual("Exact", parsedInstance.Precision);
            Assert.AreEqual("$", parsedInstance.Unit);
        }

        [TestMethod]
        public void Deserialize3()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\": \"AmountOfMoney\", \"value\":5, \"precision\": \"Exact\", \"unit\": \"USD\"}");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as AmountOfMoney;
            Assert.IsNotNull(parsedInstance);
            Assert.AreEqual(5f, parsedInstance.Value);
            Assert.AreEqual("Exact", parsedInstance.Precision);
            Assert.AreEqual("USD", parsedInstance.Unit);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class MusicTrackTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\":\"MusicTrack\", \"value\": \"Bohemian Rhapsody\" }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as MusicTrack;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual("Bohemian Rhapsody", parsedInstance.Value);
        }
    }
}

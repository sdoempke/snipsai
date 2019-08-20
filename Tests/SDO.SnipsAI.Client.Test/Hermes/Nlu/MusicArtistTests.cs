using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class MusicArtistTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\":\"MusicArtist\", \"value\": \"Radiohead\" }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as MusicArtist;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual("Radiohead", parsedInstance.Value);
        }
    }
}

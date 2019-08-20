using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Nlu;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.Nlu
{
    [TestClass]
    public class MusicAlbumTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<ValueBase>("{ \"kind\":\"MusicAlbum\", \"value\": \"Nevermind\" }");
            Assert.IsNotNull(instance);

            var parsedInstance = instance as MusicAlbum;
            Assert.IsNotNull(parsedInstance);

            Assert.AreEqual("Nevermind", parsedInstance.Value);
        }
    }
}

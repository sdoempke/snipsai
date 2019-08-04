using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SDO.SnipsAI.Client.Hermes.Tts;
using System;

namespace SDO.SnipsAI.Client.Test.Hermes.TTS
{

    [TestClass]
    public class SayMessageTest
    {
        [TestMethod]
        public void Deserialize()
        {
            var instance = JsonConvert.DeserializeObject<SayMessage>("{\"id\":\"4c5f8db3-8fde-420b-8577-d2cd74081adb\",\"lang\":\"de\",\"siteId\":\"Default\",\"sessionId\":\"29c2364f-3a35-4f95-a18c-a29af375abd9\",\"text\":\"Ja muss sie sofort\"}");
            Assert.IsNotNull(instance);
            Assert.AreEqual("4c5f8db3-8fde-420b-8577-d2cd74081adb", instance.Id);
            Assert.AreEqual("de", instance.Language);
            Assert.AreEqual("Default", instance.SiteId);
            Assert.AreEqual("29c2364f-3a35-4f95-a18c-a29af375abd9", instance.SessionId);
            Assert.AreEqual("Ja muss sie sofort", instance.Text);
        }
    }
}

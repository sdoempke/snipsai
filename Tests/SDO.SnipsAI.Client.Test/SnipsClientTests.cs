using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDO.SnipsAI.Client.Test
{
    [TestClass]
    public class SnipsClientTests
    {

        /// <summary>
        /// Tests the IsQueue method with a wildcard 
        /// </summary>
        [TestMethod]
        public void IsQueueWithWildCard()
        {
            string wildCardContent = null;
            var result = SnipsClient.IsQueue("hermes/intent/#", "hermes/intent/sdoempke:test", out wildCardContent);

            Assert.IsTrue(result);
            Assert.AreEqual("sdoempke:test", wildCardContent);
        }

        /// <summary>
        /// Tests the IsQueue method without a wildcard 
        /// </summary>
        [TestMethod]
        public void IsQueueWithoutWildCard()
        {
            string wildCardContent = null;
            var resultWithSuccess = SnipsClient.IsQueue("hermes/hotword/toggleOn", "hermes/hotword/toggleOn", out wildCardContent);

            Assert.IsTrue(resultWithSuccess);
            Assert.IsNull(wildCardContent);

            wildCardContent = null;
            var resultWithFailure = SnipsClient.IsQueue("hermes/hotword/toggleOn", "hermes/hotword/toggleOff", out wildCardContent);

            Assert.IsFalse(resultWithFailure);
            Assert.IsNull(wildCardContent);
        }
    }
}

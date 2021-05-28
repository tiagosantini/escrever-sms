using EscreverSMS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class SMSTests
    {
        [TestMethod]
        public void TestarInputValido()
        {
            SMS sms = new SMS("SEMPRE ACESSO O DOJOPUZZLES");

            Assert.AreEqual("77773367_7773302_222337777_777766606660366656667889999_9999555337777", sms.Processar());
        }
    }
}

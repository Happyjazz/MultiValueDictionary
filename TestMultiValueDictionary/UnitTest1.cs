using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiValueDictionary;

namespace TestMultiValueDictionary
{
    [TestClass]
    public class UnitTest1
    {
        public static MultiValueDictionary<string, string> mvd = new MultiValueDictionary<String, String>();

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
             mvd = new MultiValueDictionary<string, string>();
        }
        [TestMethod]
        public void TestCount()
        {
            int result = mvd.Count;
            Debug.Print(result.ToString());
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void TestAdd()
        {
            bool result = mvd.Add("SomeMovie", "192.12.33.4");
            Debug.Print(result.ToString());
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGet()
        {
            String key = "SomeMovie";
            ISet<String> valueSet = mvd.Get(key);
            Assert.IsTrue(valueSet.Contains("192.12.33.4"));
        }
    }
}

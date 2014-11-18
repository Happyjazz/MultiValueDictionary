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

        [TestMethod]
        public void A_TestCount()
        {
            mvd = new MultiValueDictionary<string, string>();
            int result = mvd.Count;
            Debug.Print(result.ToString());
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void B_TestAdd()
        {
            mvd = new MultiValueDictionary<string, string>();
            bool result = mvd.Add("SomeMovie", "192.12.33.4");
            Debug.Print(result.ToString());
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C_TestGet()
        {
            mvd = new MultiValueDictionary<string, string>();
            String key = "SomeMovie";
            String value = "192.12.33.4";
            mvd.Add(key, value);
            ISet<String> valueSet = mvd.Get(key);
            Assert.IsTrue(valueSet.Contains("192.12.33.4"));
        }

        [TestMethod]
        public void D_TestContainsKey()
        {
            mvd = new MultiValueDictionary<string, string>();
            String key = "SomeMovie";
            String value = "192.12.33.4";
            mvd.Add(key, value);

            Assert.IsTrue(mvd.ContainsKey(key));
        }

        [TestMethod]
        public void E_TestRemove()
        {
            mvd = new MultiValueDictionary<string, string>();
            String key = "SomeMovie";
            String value = "192.12.33.4";
            mvd.Add(key, value);

            Assert.IsTrue(mvd.Remove(key, value));
        }
    }
}

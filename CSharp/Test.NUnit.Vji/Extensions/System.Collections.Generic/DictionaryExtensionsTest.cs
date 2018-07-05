using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace System.Collections.Generic {

    [TestFixture]
    [BootstrapLog4net]
    public class DictionaryExtensionsTest : NUnitStdTestCaseImpl {

        [Test]
        public void TestToText() {
            IDictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("bob", "robert");
            dict.Add("mike", "michael");
            Assert.AreEqual("{bob => \"robert\", mike => \"michael\"}", dict.ToText());
        }

    }
}
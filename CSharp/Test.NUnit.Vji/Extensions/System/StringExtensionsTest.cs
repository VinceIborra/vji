using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace System {

    [TestFixture]
    public class StringExtensionsTest : NUnitStdTestCaseImpl {

        [Test]
        public void TestToText() {
            string str = "bob";
            Assert.AreEqual("\"bob\"", str.ToText());
        }

    }
}
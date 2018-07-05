
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Vji.Sanity
{
    [TestFixture]
    public class Test1
    {
        [Test]
        public void TestMethod()
        {
            IList<string> list = new List<string>() { "a", "b", "c"};
            //string str = list.RemoveAt(0);
            
            Assert.That(list, Is.EqualTo(new List<string>() {"b", "c"}));
            //Assert.That(str, Is.EqualTo("a"));
        }
    }
}

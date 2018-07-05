using System;
using NUnit.Framework;
using Vji.Mvc;
using Vji.Mock.Standard.Mvc;

namespace Vji.Standard.Mvc {
    
    [TestFixture]
    public class CommandLineInputImplTest {
        
        [Test]
        public void TestNext() {
            
            MockLineSourceImpl lineSource = new MockLineSourceImpl();
            lineSource.AddLine("doit");
            
            MockParserImpl parser = new MockParserImpl();
            
            CommandLineInputImpl input = new CommandLineInputImpl();
            input.LineSource = lineSource;
            input.Parser = parser;
            
            Command command = input.Next();
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(DoitCommand)));
        }
    }
}
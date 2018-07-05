using System;
using System.Collections.Generic;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace Vji.Configuration {
    
    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class OptionsProcessorImplTest : NUnitStdTestCaseImpl {
        
        [SetUp]
        public void TestInitialize() {
            base.Initialize();
        }
        
        [Test]
        public void TestProcess() {
            
            IList<string> parameters = (IList<string>) this.Ctx.GetObject("Parameters");
            IList<OptionConfiguration> optionsConfiguration = (IList<OptionConfiguration>) this.Ctx.GetObject("OptionsConfiguration");
            
            OptionsProcessorImpl processor = new OptionsProcessorImpl();
            processor.OptionsConfiguration = optionsConfiguration;
            processor.Parameters = parameters;
            processor.Process();
            
            Assert.IsNotNull(processor.Options);
            Assert.AreEqual(true, processor.Options["flagOption"]);
            Assert.AreEqual("someoptionstring", processor.Options["optionConfiguration1"]);
            Assert.AreEqual(123, processor.Options["optionConfiguration2"]);
            Assert.AreEqual(new List<string>{"someargumentstring", "456"}, processor.RemainderParameters);
        }
        
        [Test]
        public void TestProcess_NotStrictAndWithAnUnconfiguredFlagOption() {
            
            string unconfiguredFlagOptionParameter = (string) this.Ctx.GetObject("UnconfiguredFlagOptionParameter");
            IList<OptionConfiguration> optionsConfiguration = (IList<OptionConfiguration>) this.Ctx.GetObject("OptionsConfiguration");
            
            IList<string> parameters = new List<string>();
            parameters.Add(unconfiguredFlagOptionParameter);
            
            OptionsProcessorImpl processor = new OptionsProcessorImpl();
            processor.OptionsConfiguration = optionsConfiguration;
            processor.Parameters = parameters;
            UsageException exception = (UsageException) Assert.Throws(typeof(UsageException), () => {
                processor.Process();                 
            });
            Assert.AreEqual("Unknown option - unconfiguredFlagOption", exception.Message);
        }
    }
}

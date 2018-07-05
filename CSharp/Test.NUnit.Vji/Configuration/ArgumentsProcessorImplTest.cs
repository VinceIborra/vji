using System;
using System.Collections.Generic;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace Vji.Configuration {
    
    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class ArgumentsProcessorImplTest : NUnitStdTestCaseImpl {
        
        [SetUp]
        public void TestInitialize() {
            base.Initialize();
        }
        
        [Test]
        public void TestProcess() {

            IList<string> parameters = (IList<string>) this.Ctx.GetObject("Parameters");
            IList<ArgumentConfiguration> argumentsConfiguration = (IList<ArgumentConfiguration>) this.Ctx.GetObject("ArgumentsConfiguration");
            
            ArgumentsProcessorImpl argumentsProcessor = new ArgumentsProcessorImpl();
            argumentsProcessor.ArgumentsConfiguration = argumentsConfiguration;
            argumentsProcessor.Parameters = parameters;
            
            argumentsProcessor.Process();
        }
    }
}

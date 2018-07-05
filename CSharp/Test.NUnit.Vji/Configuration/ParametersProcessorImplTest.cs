using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace Vji.Configuration {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class ParametersProcessorImplTest : NUnitStdTestCaseImpl {

        private ConfigurationFactory ConfigurationFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            ConfigurationFactory = (ConfigurationFactory) Ctx.GetObject("ConfigurationFactory");
        }

        [Test]
        public void TestProcess() {

            IList<string> parameters = (IList<string>) this.Ctx.GetObject("Parameters");
            OptionsProcessor optionsProcessor = (OptionsProcessor) this.Ctx.GetObject("OptionsProcessor");
            ArgumentsProcessor argumentsProcessor = (ArgumentsProcessor) this.Ctx.GetObject("ArgumentsProcessor");
            ParametersProcessorImpl parametersProcessor = new ParametersProcessorImpl();
            parametersProcessor.Parameters = parameters;
            parametersProcessor.OptionsProcessor = optionsProcessor;
            parametersProcessor.ArgumentsProcessor = argumentsProcessor;

            parametersProcessor.Process();
        }

    }
}

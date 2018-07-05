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
    public class ConfigurationFactoryImplTest : NUnitStdTestCaseImpl {

        private ConfigurationFactory ConfigurationFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            ConfigurationFactory = (ConfigurationFactory) Ctx.GetObject("ConfigurationFactory");
        }

        [Test]
        public void TestNewOptionConfiguration() {
            OptionConfiguration optionConfiguration = ConfigurationFactory.NewOptionConfiguration(
                "optionName",
                typeof(string),
                "optionFormat",
                true,
                "usage information"
            );
            Assert.IsNotNull(optionConfiguration);
            Assert.IsInstanceOf(typeof(OptionConfigurationImpl), optionConfiguration);
            Assert.AreEqual("optionName", optionConfiguration.Name);
            Assert.AreEqual(typeof(string), optionConfiguration.ValueType);
            Assert.AreEqual("optionFormat", optionConfiguration.ValueFormat);
            Assert.AreEqual(true, optionConfiguration.Mandatory);
            Assert.AreEqual("usage information", optionConfiguration.Usage);
        }

        [Test]
        public void TestNewArgumentConfiguration() {
            ArgumentConfiguration argumentConfiguration = this.ConfigurationFactory.NewArgumentConfiguration(
                "argumentName",
                typeof(string),
                "argumentFormat",
                true,
                "usage information"
        	);
            Assert.IsNotNull(argumentConfiguration);
            Assert.IsInstanceOf(typeof(ArgumentConfigurationImpl), argumentConfiguration);
            Assert.AreEqual("argumentName", argumentConfiguration.Name);
            Assert.AreEqual(typeof(string), argumentConfiguration.ValueType);
            Assert.AreEqual("argumentFormat", argumentConfiguration.ValueFormat);
            Assert.AreEqual(true, argumentConfiguration.Mandatory);
            Assert.AreEqual("usage information", argumentConfiguration.Usage);
        }

        [Test]
        public void TestNewCompositeConfigProcessor() {
            IList<ConfigSource> configProcessors = new List<ConfigSource>();
        	ConfigSource compositeConfigProcessor = this.ConfigurationFactory.NewCompositeConfigProcessor(configProcessors);
            Assert.IsNotNull(compositeConfigProcessor);
            Assert.IsInstanceOf(typeof(CompositeConfigProcessorImpl), compositeConfigProcessor);
            CompositeConfigProcessorImpl compositeConfigProcessorImpl = compositeConfigProcessor as CompositeConfigProcessorImpl;
            Assert.AreEqual(configProcessors, compositeConfigProcessorImpl.ConfigProcessors);
        }

        [Test]
        public void TestNewContextProcessorImpl() {
        	ConfigSource contextProcessor = this.ConfigurationFactory.NewContextProcessor();
            Assert.IsNotNull(contextProcessor);
            Assert.IsInstanceOf(typeof(ContextProcessorImpl), contextProcessor);
        }

        [Test]
        public void TestNewOptionsProcessor() {
            OptionConfiguration optionConfiguration = ConfigurationFactory.NewOptionConfiguration(
                "optionName",
                typeof(string),
                "optionFormat",
                true,
                "usage information"
            );
        	IList<OptionConfiguration> optionsConfiguration = new List<OptionConfiguration>();
        	optionsConfiguration.Add(optionConfiguration);
        	
        	OptionsProcessor processor = this.ConfigurationFactory.NewOptionsProcessor(optionsConfiguration);
            Assert.IsNotNull(processor);
            Assert.IsInstanceOf(typeof(OptionsProcessorImpl), processor);
            OptionsProcessorImpl processorImpl = processor as OptionsProcessorImpl;
            Assert.AreEqual(optionsConfiguration, processorImpl.OptionsConfiguration);
        }

        [Test] public void TestNewParametersProcessor() {
            
            IList<string> parameters = (IList<string>) this.Ctx.GetObject("Parameters");
            OptionsProcessor optionsProcessor = (OptionsProcessor) this.Ctx.GetObject("OptionsProcessor");
            ArgumentsProcessor argumentsProcessor = (ArgumentsProcessor) this.Ctx.GetObject("ArgumentsProcessor");
            
            ParametersProcessor parametersProcessor = this.ConfigurationFactory.NewParametersProcessor(
                parameters,
                optionsProcessor,
                argumentsProcessor
            );
            
            Assert.That(parametersProcessor, Is.Not.Null);
            Assert.That(parametersProcessor, Is.InstanceOf(typeof(ParametersProcessorImpl)));
            ParametersProcessorImpl parametersProcessorImpl = (ParametersProcessorImpl) parametersProcessor;
            Assert.That(parametersProcessorImpl.Parameters, Is.EqualTo(parameters));
            Assert.That(parametersProcessorImpl.OptionsProcessor, Is.EqualTo(optionsProcessor));
            Assert.That(parametersProcessorImpl.ArgumentsProcessor, Is.EqualTo(argumentsProcessor));
        }
        
        [Test]
        public void TestNewUsageGeneratorImpl() {
            string programName = "the_program";
            OptionConfiguration optionConfiguration = ConfigurationFactory.NewOptionConfiguration(
                "optionName",
                typeof(string),
                "optionFormat",
                true,
                "usage information"
            );
        	IDictionary<string, OptionConfiguration> optionsConfiguration = new Dictionary<string, OptionConfiguration>();
        	optionsConfiguration.Add("bob", optionConfiguration);
        	
            UsageGenerator usageGenerator = this.ConfigurationFactory.NewUsageGenerator(
                programName,
                optionsConfiguration
            );
            Assert.IsNotNull(usageGenerator);
            Assert.IsInstanceOf(typeof(UsageGeneratorImpl), usageGenerator);
            UsageGeneratorImpl usageGeneratorImpl = usageGenerator as UsageGeneratorImpl;
            Assert.AreEqual(optionsConfiguration, usageGeneratorImpl.OptionsConfiguration);
        }

    }
}
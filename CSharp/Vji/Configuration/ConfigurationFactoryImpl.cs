using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Configuration {
    public class ConfigurationFactoryImpl : ConfigurationFactory {

        public ConfigSource NewContextProcessor() {
            ConfigSource processor = new ContextProcessorImpl();
            return processor;
        }
        
        public OptionConfiguration NewOptionConfiguration(
            string optionName,
            Type type,
            string format,
            bool mandatory,
            string usage
        ) {
            OptionConfigurationImpl optionConfiguration = new OptionConfigurationImpl();
            optionConfiguration.Name = optionName;
            optionConfiguration.ValueType = type;
            optionConfiguration.ValueFormat = format;
            optionConfiguration.Mandatory = mandatory;
            optionConfiguration.Usage = usage;
            return optionConfiguration;
        }

        public ArgumentConfiguration NewArgumentConfiguration(
            string argumentName,
            Type type,
            string format,
            bool mandatory,
            string usage
		) {
            ArgumentConfigurationImpl argumentConfiguration = new ArgumentConfigurationImpl();
            argumentConfiguration.Name = argumentName;
            argumentConfiguration.ValueType = type;
            argumentConfiguration.ValueFormat = format;
            argumentConfiguration.Mandatory = mandatory;
            argumentConfiguration.Usage = usage;
            return argumentConfiguration;
        }

        public OptionsProcessor NewOptionsProcessor(
            IList<OptionConfiguration> optionsConfiguration
        ) {
			OptionsProcessorImpl processor = new OptionsProcessorImpl();
			processor.OptionsConfiguration = optionsConfiguration;
			return processor;
        }

        public ArgumentsProcessor NewArgumentsProcessor(
            IList<ArgumentConfiguration> argumentConfiguration
        ) {
            ArgumentsProcessorImpl processor = new ArgumentsProcessorImpl();
            processor.ArgumentsConfiguration = argumentConfiguration;
            return processor;
        }

        public ParametersProcessor NewParametersProcessor(
            IList<string> parameters,
            OptionsProcessor optionsProcessor,
            ArgumentsProcessor argumentsProcessor
        ) {
            ParametersProcessorImpl processor = new ParametersProcessorImpl();
            processor.Parameters = parameters;
            processor.OptionsProcessor = optionsProcessor;
            processor.ArgumentsProcessor = argumentsProcessor;
            return processor;
        }

        public ConfigSource NewCompositeConfigProcessor(IList<ConfigSource> configProcessors) {
            CompositeConfigProcessorImpl processor = new CompositeConfigProcessorImpl();
            processor.ConfigProcessors = configProcessors;
            return processor;
        }
        
        public UsageGenerator NewUsageGenerator(
            string programName,
            IDictionary<string, OptionConfiguration> optionsConfiguration
        ) {
            UsageGeneratorImpl usageGenerator = new UsageGeneratorImpl();
            usageGenerator.OptionsConfiguration = optionsConfiguration;
            return usageGenerator;
        }
    }
}

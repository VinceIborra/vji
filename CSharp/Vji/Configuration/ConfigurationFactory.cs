using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Configuration {
    public interface ConfigurationFactory {

        OptionConfiguration NewOptionConfiguration(
            string optionName,
            Type type,
            string format,
            bool mandatory,
            string usage
        );

        ArgumentConfiguration NewArgumentConfiguration(
            string argumentName,
            Type type,
            string format,
            bool mandatory,
            string usage
		);
		
		ConfigSource NewContextProcessor();

        OptionsProcessor NewOptionsProcessor(
            IList<OptionConfiguration> optionsConfiguration
        );

        ArgumentsProcessor NewArgumentsProcessor(
            IList<ArgumentConfiguration> argumentConfiguration
        );

        ParametersProcessor NewParametersProcessor(
            IList<string> parameters,
            OptionsProcessor optionsProcessor,
            ArgumentsProcessor argumentsProcessor
        );
		
		ConfigSource NewCompositeConfigProcessor(IList<ConfigSource> configProcessors);

		UsageGenerator NewUsageGenerator(
		    string programName,
		    IDictionary<string, OptionConfiguration> optionsConfiguration
		);
    }
}
using System;
using System.Collections.Generic;
using Vji.Exceptions;

namespace Vji.Configuration {
    public class OptionsProcessorImpl : OptionsProcessor, ConfigSource  {

        private class OptionAndValue {
            public string Option { set; get; }
            public string Value { set; get; }
        }
        
        public bool Strict { set; get; }
        public IList<OptionConfiguration> OptionsConfiguration { set; get; }
        public IDictionary<string, OptionConfiguration> OptionsConfigurationHash { private set; get; }
        public IList<string> Parameters { set; private get; }
        public IDictionary<string, object> Options { get; private set; }
        public IList<string> RemainderParameters { private set; get; }

        public object Get(string key) {
            throw new Exception("Under construction");
        }

        public IList<string> Keys {
            get {
                throw new Exception("Under construction");
            }
        }

        public OptionsProcessorImpl() {
            this.Strict = true;
            this.OptionsConfiguration = new List<OptionConfiguration>();
            this.OptionsConfigurationHash = new Dictionary<string, OptionConfiguration>();
            this.Parameters = null;
            this.Options = new Dictionary<string, object>();
            this.RemainderParameters = new List<string>();
        }
        
        private void EnsureOptionsAreEasilyAccessible() {
            foreach(OptionConfiguration optionConfiguration in this.OptionsConfiguration) {
                this.OptionsConfigurationHash[optionConfiguration.Name] = optionConfiguration;
            }
        }
        
        private void EnsureParametersAreInitialised() {
            if (this.Parameters == null) {
                this.Parameters = Environment.GetCommandLineArgs();
            }
        }
        
        private bool IsOptionNameKnown(string option) {
            return this.OptionsConfigurationHash.ContainsKey(option);
        }
        
        private void AssertOptionNameIsKnown(string option) {
            if (!this.IsOptionNameKnown(option)) {
                throw new UsageException("Unknown option - " + option);
            }
        }
        
        private void AssertFlagOption(string option) {
            if (this.OptionsConfigurationHash[option].ValueType != typeof(Boolean)) {
                throw new UsageException("No value expected with the use of this option - " + option);
            }
        }
        
        private bool IsParameterAnArgument(string parameter) {
            if (!parameter.StartsWith("/")) {
                return true;
            }
            else {
                return false;
            }
        }
        
        private bool IsAFlagOption(string parameter) {
            
            // Strip the option character 
            string optionAndValue = parameter.Substring(1);
            
            // Test for option/value separator
            int separatorIdx = optionAndValue.IndexOf(":");
            
            // If the separator wasn't found, then it must be a flag option
            if (separatorIdx < 0) {
                return true;
            }
            
            // Otherwise, it must be an option/value option
            else {
                return false;
            }
        }
        
        private void ProcessArgument(string parameter) {
            this.RemainderParameters.Add(parameter);
        }
        
        private string StripOptionCharacter(string parameter) {
            return parameter.Substring(1);
        }
        
        private void ProcessFlagOption(string parameter) {
            string option = this.StripOptionCharacter(parameter);
            if (this.Strict) {
                this.AssertOptionNameIsKnown(option);
                this.AssertFlagOption(option);
            }
            this.Options[option] = true;
        }
        
        private OptionAndValue SplitOptionAndValueString(string optionAndValueStr) {
            OptionAndValue optionAndValue = new OptionAndValue();
            int separatorIdx = optionAndValueStr.IndexOf(":");
            optionAndValue.Option = optionAndValueStr.Substring(0, separatorIdx);
            optionAndValue.Value = optionAndValueStr.Substring(separatorIdx + 1, optionAndValueStr.Length - (separatorIdx+1));
            return optionAndValue;
        }

        private void AssertHandledValueType(Type type) {
            if (type != typeof(string)
            &&  type != typeof(DateTime)
            &&  type != typeof(long)) {
                throw new InternalErrorException();
            }
        }
        
        private void ApplyOptionConfiguration(OptionConfiguration optionConfiguration, string option, string value) {
            this.AssertHandledValueType(optionConfiguration.ValueType);
            if (optionConfiguration.ValueType == typeof(string)) {
                Options[option] = value;
            }
            else if (optionConfiguration.ValueType == typeof(DateTime)) {
                Options[option] = DateTime.ParseExact(value, optionConfiguration.ValueFormat, null);
            }
            else if (optionConfiguration.ValueType == typeof(long)) {
                Options[option] = Convert.ToInt64(value);
            }
            else {
                throw new InternalErrorException();
            }
        }
        
        private void ApplyNonStrictOptionConfiguration(string option, string value) {
            Options[option] = value;
        }
        
        private void ProcessValueOption(string parameter) {
            string optionAndValueStr = this.StripOptionCharacter(parameter);
            OptionAndValue optionAndValue = this.SplitOptionAndValueString(optionAndValueStr);
            if (this.Strict) {
                this.AssertOptionNameIsKnown(optionAndValue.Option);
            }
            if (!this.IsOptionNameKnown(optionAndValue.Option)) {
                this.ApplyNonStrictOptionConfiguration(optionAndValue.Option, optionAndValue.Value);
            }
            else {
                this.ApplyOptionConfiguration(
                    OptionsConfigurationHash[optionAndValue.Option],
                    optionAndValue.Option,
                    optionAndValue.Value
                );
            }
        }

        private void ProcessParameters() {
            foreach (string parameter in Parameters) {
                System.Console.WriteLine("parameter = " + parameter);
                if (this.IsParameterAnArgument(parameter)) {
                    this.ProcessArgument(parameter);
                }
                else if (this.IsAFlagOption(parameter)) {
                    this.ProcessFlagOption(parameter);
                }
                else {
                    this.ProcessValueOption(parameter);
                }
            }
        }
        
        private void AssertMandatoryOptionsArePresent() {
            foreach(OptionConfiguration optionConfiguration in this.OptionsConfiguration) {
                if (optionConfiguration.Mandatory && !Options.ContainsKey(optionConfiguration.Name)) {
                    throw new UsageException("Error: Option " + optionConfiguration.Name + " is mandatory.");
                }
            }
        }

        public void Process() {
            this.EnsureOptionsAreEasilyAccessible();
            this.EnsureParametersAreInitialised();
            this.ProcessParameters();
            this.AssertMandatoryOptionsArePresent();
        }
    }
}

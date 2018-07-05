using System;
using System.Collections.Generic;

namespace Vji.Configuration {

    public class ArgumentsProcessorImpl : ArgumentsProcessor {
        
        private Queue<string> ParametersQueue { set; get; }
        private Queue<ArgumentConfiguration> ArgumentConfigurationsQueue { set; get; }
        
        public IList<string> Parameters { set; private get; }
        public IList<ArgumentConfiguration> ArgumentsConfiguration { set; get; }
        public IDictionary<string, object> Arguments { set; get; }
        
        public object Get(string key) {
            throw new Exception("Under construction");
        }

        public IList<string> Keys {
            get {
                throw new Exception("Under construction");
            }
        }
        
        public ArgumentsProcessorImpl() {
            this.Arguments = new Dictionary<string, object>();
        }
        
        private void QueueParameters() {
            this.ParametersQueue = new Queue<string>();
            foreach(string parameter in this.Parameters) {
                this.ParametersQueue.Enqueue(parameter);
            }
        }
        
        private void QueueOptions() {
            this.ArgumentConfigurationsQueue = new Queue<ArgumentConfiguration>();
            foreach(ArgumentConfiguration argumentConfiguration in this.ArgumentsConfiguration) {
                this.ArgumentConfigurationsQueue.Enqueue(argumentConfiguration);
            }
        }

        private bool ThereAreMoreParametersToProcess() {
            return (this.ParametersQueue.Count > 0);
        }

        private bool ThereAreMoreArgumentConfigurationsToProcess() {
            return (this.ArgumentConfigurationsQueue.Count > 0);
        }
        
        private bool ThereAreMandatoryArgumentConfigurationYetToProcess() {
            throw new Exception("Under construction");
        }
        
        private void AssertThatNotRunOutOfParameters() {
            if (!this.ThereAreMoreParametersToProcess() && this.ThereAreMandatoryArgumentConfigurationYetToProcess()) {
                throw new UsageException("Missing arguments - " + String.Join(", ", this.ArgumentConfigurationsQueue));
            }
        }
        
        private void AssertThatNotRunOutOfArgumentConfigurations() {
            if (!this.ThereAreMoreArgumentConfigurationsToProcess() && this.ThereAreMoreParametersToProcess()) {
                throw new UsageException("Extra information found at end of argument list.");
            }
        }
        
        private string NextParameter() {
            return this.ParametersQueue.Dequeue();
        }

        private ArgumentConfiguration NextArgumentConfiguration() {
            return this.ArgumentConfigurationsQueue.Dequeue();
        }
        
        private void ApplyArgumentConfiguration(string parameter, ArgumentConfiguration argumentConfiguration) {
            this.Arguments[argumentConfiguration.Name] = parameter;
        }

        private void ProcessParameters() {
            do {
                this.AssertThatNotRunOutOfParameters();
                this.AssertThatNotRunOutOfArgumentConfigurations();
                this.ApplyArgumentConfiguration(
                    this.NextParameter(),
                    this.NextArgumentConfiguration()
                );
            } while (this.ThereAreMoreParametersToProcess() && this.ThereAreMoreArgumentConfigurationsToProcess());
        }
        
        public void Process() {
            this.QueueParameters();
            this.QueueOptions();
            this.ProcessParameters();
        }
    }
}

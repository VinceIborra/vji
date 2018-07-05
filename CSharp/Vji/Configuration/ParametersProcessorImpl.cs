
using System;
using System.Collections.Generic;

namespace Vji.Configuration {

    public class ParametersProcessorImpl : ParametersProcessor {
        
        public IList<string> Parameters;
        public OptionsProcessor OptionsProcessor { set; get; }
        public ArgumentsProcessor ArgumentsProcessor { set; get; }

        public object Get(string key) {
            throw new Exception("Under construction");
        }

        public IList<string> Keys {
            get {
                throw new Exception("Under construction");
            }
        }
        
        public void Process() {
            
            // Process options first
            if (this.OptionsProcessor != null) {
                this.OptionsProcessor.Parameters = this.Parameters;
                this.OptionsProcessor.Process();
            }
            
            // And then the arguments
            if (this.ArgumentsProcessor != null) {
                if (this.OptionsProcessor != null) {
                    this.ArgumentsProcessor.Parameters = this.OptionsProcessor.RemainderParameters;
                }
                else {
                    this.ArgumentsProcessor.Parameters = this.Parameters;
                }
                this.ArgumentsProcessor.Process();
            }
        }
    }
}

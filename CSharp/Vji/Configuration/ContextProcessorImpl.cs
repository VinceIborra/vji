using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Configuration {
    public class ContextProcessorImpl  : ConfigSource {


        public object Get(string key) {
            throw new Exception("Under construction");
        }

        public IList<string> Keys {
            get {
                throw new Exception("Under construction");
            }
        }


        private bool Processed { set; get; }
        public IDictionary<string, object> Cfg {
            private set;
            get;
        }

        public ContextProcessorImpl() {
            Processed = false;
            Cfg = new Dictionary<string, object>();
        }

        public void Process() {

            // No need to do anything if already processed
            if (Processed) {
                return;
            }

            // Process
            Cfg.Add("Date", DateTime.Now);
            Processed = true;
        }
    }
}

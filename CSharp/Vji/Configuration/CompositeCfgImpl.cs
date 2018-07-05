using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Configuration {
    public class CompositeConfigProcessorImpl : ConfigSource {

        public object Get(string key) {
            throw new Exception("Under construction");
        }

        public IList<string> Keys {
            get {
                throw new Exception("Under construction");
            }
        }

        public IList<ConfigSource> ConfigProcessors { set; get; }
            
        IDictionary<string, ConfigSource> Configurations { set; get; }
        
        public IDictionary<string, object> Cfg { set; get; }
        public void Process() {
            //foreach (string cfgKey in Configurations.Keys) {
            //    foreach(string key in Configurations[cfgKey].Cfg.Keys) {
            //        Cfg.Add(
            //            String.Format("{0}.{1}", cfgKey, key),
            //            Configurations[cfgKey].Cfg[key]
            //        ); 
            //    }
            //}
            throw new Exception("Under construction");
        }
    }
}

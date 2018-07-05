using System;

namespace Vji.Configuration {
    public class OptionConfigurationImpl : OptionConfiguration {

        public string Name { set; get; }

        public Type ValueType { set; get; }

        public string ValueFormat { set; get; }

        public bool Mandatory { set; get; }

        public string Usage { set; get; }

        public OptionConfigurationImpl() {
            Mandatory = false;
        }

    }
}

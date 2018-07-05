using System;

namespace Vji.Configuration {
	public class ArgumentConfigurationImpl : ArgumentConfiguration {
        public string Name { set; get; }

        public Type ValueType { set; get; }

        public string ValueFormat { set; get; }

        public bool Mandatory { set; get; }

        public string Usage { set; get; }

        public ArgumentConfigurationImpl() {
            Mandatory = false;
        }
	}
}

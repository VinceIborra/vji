using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Configuration {
    public class UsageGeneratorImpl : UsageGenerator {

        public string ProgramName { set; get; }
        public IDictionary<string, OptionConfiguration> OptionsConfiguration { set; get; }

        public string GenerateHeaderInfo() {
            string str = "";
            str += "Usage:";
            str += ProgramName;
            foreach (string label in OptionsConfiguration.Keys) {
                OptionConfiguration option = OptionsConfiguration[label];
                str += " ";
                if (!option.Mandatory) {
                    str += "[";
                }
                str += "/" + label + ":<value>";
                if (!option.Mandatory) {
                    str += "]";
                }
            }
            str += "\n";
            return str;
        }

        public string GenerateOptionsInfo() {
            string str = "";
            str += "Options:\n";
            foreach (string label in OptionsConfiguration.Keys) {
                OptionConfiguration option = OptionsConfiguration[label];
                str += "/" + label + "    " + option.Usage + "\n";
            }

            return str;
        }

        public string Generate() {
            return   GenerateHeaderInfo()
            + "\n" + GenerateOptionsInfo();
        }
    }
}
        //Type Type { get; }
        //string Format { get; }
        //bool Mandatory { get; }
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Spring.Objects.Factory.Config;
using Vji.Configuration;

namespace Vji.Spring.Configuration {
    class ConfigSectionVariableSourceImpl : IVariableSource, ConfigSource {

        public object Get(string key) {
            throw new Exception("Under construction");
        }

        public IList<string> Keys {
            get {
                throw new Exception("Under construction");
            }
        }

        public string SectionName { set; get; }

        private IDictionary<string, string> Values { set; get; }
        public IDictionary<string, object> Cfg { set; get; }

        private ConfigurationPropertyAttribute GetPropertyAttribute(PropertyInfo property) {
            foreach (Attribute attribute in property.GetCustomAttributes(false)) {
                if (attribute is ConfigurationPropertyAttribute) {
                    return attribute as ConfigurationPropertyAttribute;
                }
            }
            return null;
        }

        private void LoadSectionValues(string sectionName)  {

            // Get the section
            ConfigurationSection section = ConfigurationManager.GetSection(sectionName) as ConfigurationSection;

            // Process all it's properties
            foreach (PropertyInfo property in section.GetType().GetProperties()) {

                // Only process configuration properties
                ConfigurationPropertyAttribute attribute = GetPropertyAttribute(property);
                if (attribute == null) {
                    continue;
                }

                // Get the name
                string name = String.Format("{0}.{1}", sectionName, attribute.Name);

                // Get the value
                object value = property.GetValue(section, null);
                string valueStr = value.ToString();

                // And store it away
                Cfg[name] = value;
                Values[name] = valueStr;
            }
        }

        private void EnsureValuesLoaded() {
            if (Values != null) {
                return;
            }
            Values = new Dictionary<string, string>();
            LoadSectionValues(SectionName);
        }

        public ConfigSectionVariableSourceImpl() {
            SectionName = null;
            Values = null;
            Cfg = new Dictionary<string, object>();
        }

        public string ResolveVariable(string name) {
            EnsureValuesLoaded();
            return Values[name];
        }

        public bool CanResolveVariable(string name) {
            EnsureValuesLoaded();
            return Values.ContainsKey(name);
        }

        public void Process() {
            EnsureValuesLoaded();
        }

    }
}
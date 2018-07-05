using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    public static class DictionaryExtensions {

        private static MethodInfo GetToTextMethod<TType>(TType obj) {

            // Get current assembly
            Assembly assembly = typeof(DictionaryExtensions).Assembly;

            // Find the ToText extension method(s)
            IList<MethodInfo> methods = new List<MethodInfo>();
			foreach (Type type in assembly.GetTypes()) {
            	if (type.IsSealed && !type.IsGenericType && !type.IsNested) {
					foreach(MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)) {
						if (method.IsDefined(typeof(ExtensionAttribute), false) && method.Name == "ToText") {
							foreach(ParameterInfo parameter in method.GetParameters()) {
								if (parameter.ParameterType.Equals(obj.GetType())) {
            						methods.Add(method);
								}
							}
						}
					}
				}
			}
			
            // Assert that there is only one method defined
            if (methods.Count() > 1) {
                throw new Exception("There are multiple(" + methods.Count + ") \"ToText\" methods declared on " + obj.GetType().Name);
            }
            
            // Return the found method or null if none found
            if (methods.Count() == 1) {
                return methods.First();
            }

            return null;
		}

        private static string GetTextString<TType>(TType obj) {

            // Get the 'ToText' method if defined for the object
            MethodInfo method = GetToTextMethod(obj);

            // Execute the method if present
            if (method != null) {
                object[] parameters = new object[] { obj };
                return (string) method.Invoke(null, parameters);
            }

            // Otherwise, fallback to ToString
            return obj.ToString();
        }

        public static string ToText<TKey, TValue>(this IDictionary<TKey, TValue> dict) {

            // Output start of dictionary marker
            string str = "{";

            // Output each entry in the dictionary
            bool first = true;
            foreach (TKey key in dict.Keys) {

                // Put comma between entries
                if (!first) {
                    str += ", ";
                }

                // Output each entry
                str += key.ToString() + " => " + GetTextString(dict[key]);

                // And make sure we keep track of when we're done with the first entry
                first = false;
            }

            // Output end of dictionary marker
            str += "}";
            return str;
        }
    }
}

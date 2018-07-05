using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using log4net;

namespace Vji.Bootstrap {
    public class AssemblyResolverImpl : AssemblyResolver {

        public ILog Logger { set; get; }
        public bool IsDone { private set; get; }
        public IList<string> IgnoredAssemblyLoadFailures { set; get; }

        private Assembly ResolveFromInstallDirectory(string assemblyName) {

            // Get the installation directory from the registry
            string installDirectoryPath;
            string registryPathName = "HKEY_LOCAL_MACHINE\\Software\\Vji";
            string registryKey = "INSTALL_DIRECTORY";
            object value = Registry.GetValue(registryPathName, registryKey, null);
            installDirectoryPath = (value == null) ? null : (string)value;

            // Build the path of the assembly from where it has to be loaded.				
            string assemblyPath = installDirectoryPath + assemblyName + ".dll";

            // Load it and return it
            Logger.Debug("Attempting to load assembly file - " + assemblyPath);
            Assembly assembly = null;
            try {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            catch (FileNotFoundException fileNotFoundException) {
                Logger.Debug("Failed -> Can't resolve from install directory: " + fileNotFoundException.Message);
            }
            catch (Exception exception) {
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
            return assembly;
        }

        private Assembly ResolveFromCommonFilesDirectory(string assemblyName) {

            // Get the installation directory from the registry
            string commonFilesPath;
            string registryPathName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion";
            string registryKey = "CommonFilesDir";
            object value = Registry.GetValue(registryPathName, registryKey, null);
            commonFilesPath = (value == null) ? null : (string)value;

            // Build the path of the assembly from where it has to be loaded.				
            string assemblyPath = commonFilesPath + "\\Vji\\" + assemblyName + ".dll";

            // Load it and return it
            Logger.Debug("Loading assembly file - " + assemblyPath);
            Assembly assembly = null;
            try {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            catch (FileNotFoundException fileNotFoundException) {
                Logger.Debug("Failed -> Can't resolve from common files directory: " + fileNotFoundException.Message);
            }
            catch (Exception exception) {
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
            return assembly;
        }

        private Assembly Handler(object sender, ResolveEventArgs args) {

            // Tell user what we are trying to resolve
            string assemblyName = args.Name.Substring(0, args.Name.IndexOf(","));
            Logger.Debug("Resolving assembly - " + assemblyName);

            // Try finding it in the install directory
            Assembly assembly;
            assembly = ResolveFromInstallDirectory(assemblyName);
            if (assembly != null) {
                return assembly;
            }

            // Otherwise try finding it in the common files area
            assembly = ResolveFromCommonFilesDirectory(assemblyName);
            if (assembly != null) {
                return assembly;
            }

            // Check to see whether we can ignore the assembly
            if (IgnoredAssemblyLoadFailures.Contains(assemblyName)) {
                Logger.Debug(String.Format("Assembly in ignored load failure list -> no further action taken."));
                return null;
            }

            // Fatal Condition - Can't find the assembly
            string message = String.Format("Could not load file from any known locations - {0}", assemblyName);
            Logger.Fatal(message);
            throw new Exception(message);
        }

        public void Bootstrap() {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(Handler);
            Logger.Debug("Assembly resolver setup.");
            IsDone = true;
        }
    }
}

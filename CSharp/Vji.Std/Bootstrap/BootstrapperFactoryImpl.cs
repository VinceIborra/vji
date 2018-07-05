using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;
using Vji.Bootstrap;
using Vji.Spring.Bootstrap;

namespace Vji.Std.Bootstrap {
    public class BootstrapperFactoryImpl : BootstrapperFactory {

        public LogBootstrapper NewLogBootstrapper() {
            LogBootstrapperImpl logBootstrapper = new LogBootstrapperImpl();
            return logBootstrapper;
        }

        public AssemblyResolver NewAssemblyResolver(LoggerSetter loggerSetter) {
            AssemblyResolverImpl assemblyResolver = new AssemblyResolverImpl();
            loggerSetter.Add(assemblyResolver);
            return assemblyResolver;
        }

        public SpringBootstrapper NewSpringBootstrapper(LoggerSetter loggerSetter) {
            SpringBootstrapperImpl springBootstrapper = new SpringBootstrapperImpl();
            loggerSetter.Add(springBootstrapper);
            return springBootstrapper;
        }

        public CompositeBootstrapper NewCompositeBootstrapper(LoggerSetter loggerSetter, IList<Bootstrapper> bootstrappers) {
            CompositeBootstrapperImpl compositeBootstrapper = new CompositeBootstrapperImpl();
            compositeBootstrapper.SubBootstrappers = bootstrappers;
            loggerSetter.Add(compositeBootstrapper);
            return compositeBootstrapper;
        }

        public Runner NewSpringRunner(LoggerSetter loggerSetter, SpringBootstrapper springBootstrapper) {
            SpringRunnerImpl runner = new SpringRunnerImpl();
            runner.SpringBootstrapper = springBootstrapper;
            loggerSetter.Add(runner);
            return runner;
        }
    }
}

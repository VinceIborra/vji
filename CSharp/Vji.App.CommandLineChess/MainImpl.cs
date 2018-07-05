using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;
using Vji.Bootstrap;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.App.CommandLineChess {
    class MainClass {
        static void Main(string[] args) {

            // Get a way to create the top level objects
            Log4netFactory log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory bootstrapperFactory = new BootstrapperFactoryImpl();
            MainFactory mainFactory = new MainFactoryClass();
            mainFactory.BootstrapperFactory = bootstrapperFactory;

            // Initialise the individual bootstrappers
            LogBootstrapper logBootstrapper = bootstrapperFactory.NewLogBootstrapper();
            LoggerSetter loggerSetter = log4netFactory.NewBootstrapDependentLoggerSetter(logBootstrapper);
            AssemblyResolver assemblyResolver = bootstrapperFactory.NewAssemblyResolver(loggerSetter);
            SpringBootstrapper springBootstrapper = bootstrapperFactory.NewSpringBootstrapper(loggerSetter);
            
            // Create the program components
            Bootstrapper bootstrapper = mainFactory.NewProgramBootstrapper(logBootstrapper, loggerSetter, assemblyResolver, springBootstrapper);
            Runner runner = bootstrapperFactory.NewSpringRunner(loggerSetter, springBootstrapper);

            // Create and run the program
            Program program = mainFactory.NewProgram(bootstrapper, runner);
            program.Run();
        }
    }
}
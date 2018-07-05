using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.App.CommandLineChess {
    public class MainFactoryClass : MainFactory {

        public BootstrapperFactory BootstrapperFactory { set; get; }

        public Bootstrapper NewProgramBootstrapper(LogBootstrapper logBootstrapper, LoggerSetter loggerSetter, AssemblyResolver assemblyResolver, SpringBootstrapper springBootstrapper) {
            IList<Bootstrapper> bootstrappers = new List<Bootstrapper>();
            bootstrappers.Add(logBootstrapper);
            bootstrappers.Add(loggerSetter);
            bootstrappers.Add(assemblyResolver);
            bootstrappers.Add(springBootstrapper);
            CompositeBootstrapper compositeBootstrapper = BootstrapperFactory.NewCompositeBootstrapper(loggerSetter, bootstrappers);
            return compositeBootstrapper;
        }

        public Program NewProgram(Bootstrapper bootstrapper, Runner runner) {
            ProgramClass program = new ProgramClass();
            program.Bootstrapper = bootstrapper;
            program.Runner = runner;
            return program;
        }
    }
}

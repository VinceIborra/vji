using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.App.CommandLineChess {
    public interface MainFactory {

        BootstrapperFactory BootstrapperFactory { set; get; }

        Bootstrapper NewProgramBootstrapper(
            LogBootstrapper logBootstrapper,
            LoggerSetter loggerSetter,
            AssemblyResolver assemblyResolver,
            SpringBootstrapper springBootstrapper
        );

        Program NewProgram(Bootstrapper bootstrapper, Runner runner);
    }
}

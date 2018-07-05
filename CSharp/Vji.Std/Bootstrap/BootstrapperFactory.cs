using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;
using Vji.Spring.Bootstrap;
using Vji.Bootstrap;

namespace Vji.Std.Bootstrap {
    public interface BootstrapperFactory {
        LogBootstrapper NewLogBootstrapper();
        AssemblyResolver NewAssemblyResolver(LoggerSetter loggerSetter);
        SpringBootstrapper NewSpringBootstrapper(LoggerSetter loggerSetter);
        CompositeBootstrapper NewCompositeBootstrapper(LoggerSetter loggerSetter, IList<Bootstrapper> bootstrappers);
        Runner NewSpringRunner(LoggerSetter loggerSetter, SpringBootstrapper springBootstrapper);
    }
}

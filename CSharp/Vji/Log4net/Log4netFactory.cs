using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;

namespace Vji.Log4net {
    public interface Log4netFactory {
        LoggerSetter NewLoggerSetter();
        LoggerSetter NewBootstrapDependentLoggerSetter(LogBootstrapper logBootstrapper);
    }
}

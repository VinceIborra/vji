using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Spring.Context;
using Spring.Context.Support;
using Vji.Log4net;

namespace Vji.Spring.Bootstrap {
    public class SpringBootstrapperImpl : SpringBootstrapper {

        public ILog Logger { set; get; }
        public bool IsDone { private set; get; }
        public IApplicationContext Ctx { private set; get; }

        public void Bootstrap() {

            Logger.Debug("Bootstrapping Spring.NET...");
            Ctx = ContextRegistry.GetContext();

            Logger.Debug("Setting object loggers.");
            LoggerSetter loggerSetter = (LoggerSetter) Ctx.GetObject("LoggerSetter");
            loggerSetter.SetLoggers();

            Logger.Debug("Bootstrapping Spring.NET - Done.");
            IsDone = true;
        }
    }
}

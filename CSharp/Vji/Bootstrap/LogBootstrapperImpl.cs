using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using Vji.Log4net;

namespace Vji.Bootstrap {
    public class LogBootstrapperImpl : LogBootstrapper, LoggerRecipient {
        
        public ILog Logger { set; get; }
        public bool IsDone { private set; get; }

        public void Bootstrap() {
            XmlConfigurator.Configure();
            Logger = LogManager.GetLogger(typeof(LogBootstrapperImpl));
            Logger.Debug("Logging bootstrapped.");
            IsDone = true;
        }
    }
}
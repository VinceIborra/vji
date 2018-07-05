using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Log4net;
using Vji.Mvc;

namespace Vji.Mock.Mvc {
    public class MockDriverImpl : Driver, LoggerRecipient {

        public ILog Logger { set; get; }

        public void Run() {
            Logger.Info("Running mock runner class...");
            Logger.Info("Running mock runner class - Finished.");
        }
    }
}

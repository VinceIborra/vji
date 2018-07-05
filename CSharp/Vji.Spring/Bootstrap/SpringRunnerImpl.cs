using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using log4net;
using Vji.Mvc;
using Vji.Bootstrap;

namespace Vji.Spring.Bootstrap {
    public class SpringRunnerImpl : Runner {

        public ILog Logger { set; get; }
        public bool IsDone { set; get; }
        public SpringBootstrapper SpringBootstrapper { set; get; }

        public void Run() {
            Logger.Debug("Running driver...");
            Driver driver = (Driver) SpringBootstrapper.Ctx.GetObject("Driver");
            driver.Run();
            Logger.Debug("Running Driver - Finished.");
            IsDone = true;
        }
    }
}

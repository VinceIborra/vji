using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Standard;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Test;
using Vji.Std.Bootstrap;

namespace Vji.Std.Test {

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class BootstrapLog4netAttribute : NfsTestAttribute {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private LogBootstrapper LogBootstrapper { set; get; }
        private LoggerSetter LoggerSetter { set; get; }

        public BootstrapLog4netAttribute() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LogBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            LoggerSetter = Log4netFactory.NewBootstrapDependentLoggerSetter(LogBootstrapper);
        }

        public override void Initialize(NfsTestCase testCase) {
            StdTestCase stdTestCase = (StdTestCase) testCase;
            LogBootstrapper.Bootstrap();
            stdTestCase.LoggerSetter = LoggerSetter;
        }

        public override void Cleanup() {
        }
    }
}

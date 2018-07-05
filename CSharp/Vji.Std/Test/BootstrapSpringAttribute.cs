using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Standard;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Test;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.Std.Test {

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class BootstrapSpringAttribute : NfsTestAttribute {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private LogBootstrapper LogBootstrapper { set; get; }
        private SpringBootstrapper SpringBootstrapper { set; get; }
        private LoggerSetter LoggerSetter { set; get; }
        
        public BootstrapSpringAttribute() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LogBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            LoggerSetter = Log4netFactory.NewBootstrapDependentLoggerSetter(LogBootstrapper);
            SpringBootstrapper = BootstrapperFactory.NewSpringBootstrapper(LoggerSetter);
        }

        public override void Initialize(NfsTestCase testCase) {
            StdTestCase standardTestCase = (StdTestCase) testCase;
            SpringBootstrapper.Bootstrap();
            standardTestCase.Ctx = SpringBootstrapper.Ctx;
        }

        public override void Cleanup() {
        }
    }
}

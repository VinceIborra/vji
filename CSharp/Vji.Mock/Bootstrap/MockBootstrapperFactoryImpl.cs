using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;
using Vji.Log4net;

namespace Vji.Mock.Bootstrap {
    public class MockBootstrapperFactoryImpl : MockBootstrapperFactory {

        public Bootstrapper NewMockBootstrapper() {
            MockBootstrapperImpl bootstrapper = new MockBootstrapperImpl();
            bootstrapper.IsDone = false;
            return bootstrapper;
        }
    }
}

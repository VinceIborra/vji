using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;

namespace Vji.Mock.Bootstrap {
    public interface MockBootstrapperFactory {
        Bootstrapper NewMockBootstrapper();
    }
}

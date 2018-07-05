using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;

namespace Vji.Bootstrap {
    public interface CompositeBootstrapper : Bootstrapper, LoggerRecipient {
    }
}

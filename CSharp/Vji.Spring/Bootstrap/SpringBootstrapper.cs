using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Vji.Log4net;
using Vji.Bootstrap;

namespace Vji.Spring.Bootstrap {
    public interface SpringBootstrapper : Bootstrapper, LoggerRecipient {
        IApplicationContext Ctx { get; }
    }
}

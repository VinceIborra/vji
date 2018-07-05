using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;

namespace Vji.Mock.Log4net {
    public interface MockLog4netFactory {
        LoggerRecipient NewMockLoggerRecipient();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Log4net;

namespace Vji.Mock.Log4net {
    public class MockLoggerRecipientImpl : LoggerRecipient {
        public ILog Logger { set; get; }
    }
}

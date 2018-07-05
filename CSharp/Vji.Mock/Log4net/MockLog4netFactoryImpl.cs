using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;

namespace Vji.Mock.Log4net {
    public class MockLog4netFactoryImpl : MockLog4netFactory {

        public LoggerRecipient NewMockLoggerRecipient() {
            MockLoggerRecipientImpl loggerRecipient = new MockLoggerRecipientImpl();
            return loggerRecipient;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;

namespace Vji.Log4net {
    public interface LoggerSetter : Bootstrapper {
        void Add(LoggerRecipient loggerRecipient);
        void SetLoggers();
    }
}

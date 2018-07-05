using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Vji.Log4net;

namespace Vji.Std.Test {
    public interface StdTestCase {
        LoggerSetter LoggerSetter { set; get; }
        IApplicationContext Ctx { set; get; }
    }
}

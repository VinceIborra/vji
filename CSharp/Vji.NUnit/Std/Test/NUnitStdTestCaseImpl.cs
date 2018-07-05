using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Spring.Context;
using Vji.Std.Test;
using Vji.Log4net;
using Vji.NUnit.Test;

namespace Vji.NUnit.Std.Test {
    public class NUnitStdTestCaseImpl : NUnitTestCaseImpl, StdTestCase {

        public LoggerSetter LoggerSetter { set; get; }
        public IApplicationContext Ctx { set; get; }

        protected NUnitStdTestCaseImpl() : base() {
            SupportedAttributeTypes.Add(typeof(BootstrapLog4netAttribute));
            SupportedAttributeTypes.Add(typeof(BootstrapSpringAttribute));
        }

    }
}

using System;
using NUnit.Framework;
using Vji.NUnit.Std.Test;
using Vji.Std.Test;

namespace Vji.Mvc {
    
    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class TestCaseImpl : NUnitStdTestCaseImpl {

        protected Vji.Mvc.Factory MvcFactory {
            get {
                return (Vji.Mvc.Factory) this.Ctx.GetObject("MvcFactory");
            }
        }

        protected Vji.Mock.Mvc.Factory MockMvcFactory {
            get {
                return (Vji.Mock.Mvc.Factory) this.Ctx.GetObject("MockMvcFactory");
            }
        }

    }
}

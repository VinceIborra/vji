using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;

namespace Vji.Mock.Bootstrap {
    public class MockBootstrapperImpl : Bootstrapper {

        public bool IsDone { set; get; }

        public void Bootstrap() {
            IsDone = true;
        }
    }
}
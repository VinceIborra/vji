using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Log4net;

namespace Vji.Bootstrap {
    public class CompositeBootstrapperImpl : CompositeBootstrapper {

        public ILog Logger { set; get; }
        public IList<Bootstrapper> SubBootstrappers { set; get; }
        public bool IsDone { private set; get; }

        public void Bootstrap() {
            foreach (Bootstrapper bootstrapper in SubBootstrappers) {
                bootstrapper.Bootstrap();
            }
            IsDone = true;
        }
    }
}

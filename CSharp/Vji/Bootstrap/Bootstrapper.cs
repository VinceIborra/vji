using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Bootstrap {
    public interface Bootstrapper {
        bool IsDone { get; }
        void Bootstrap();
    }
}

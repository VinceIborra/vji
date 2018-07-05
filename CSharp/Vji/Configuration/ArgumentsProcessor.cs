using System;
using System.Collections.Generic;

namespace Vji.Configuration {
    public interface ArgumentsProcessor : ConfigSource {
        IList<string> Parameters { set; }
    }
}

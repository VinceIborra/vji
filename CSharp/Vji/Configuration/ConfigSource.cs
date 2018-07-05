using System.Collections.Generic;

namespace Vji.Configuration {
    public interface ConfigSource : Config {
        void Process();
    }
}

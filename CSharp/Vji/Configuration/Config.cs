using System.Collections.Generic;

namespace Vji.Configuration {
    public interface Config {
        IList<string> Keys { get; }
        object Get(string key);
    }
}

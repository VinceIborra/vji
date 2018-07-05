using System.Collections.Generic;

namespace Vji.Configuration {
    public interface OptionsProcessor {
        
        IList<string> Parameters { set; }
        
        IList<string> RemainderParameters { get; }
        IDictionary<string, object> Options { get; }
        
        void Process();
    }
}

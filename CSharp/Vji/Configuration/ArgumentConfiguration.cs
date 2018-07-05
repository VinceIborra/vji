using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Configuration {
    public interface ArgumentConfiguration {
        string Name { get; }
        Type ValueType { get; }
        string ValueFormat { get; }
        bool Mandatory { get; }
        string Usage { get; }
    }
}

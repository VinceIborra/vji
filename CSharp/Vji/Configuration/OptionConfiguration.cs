using System;

namespace Vji.Configuration {
    public interface OptionConfiguration {
        string Name { get; }
        Type ValueType { get; }
        string ValueFormat { get; }
        bool Mandatory { get; }
        string Usage { get; }
    }
}

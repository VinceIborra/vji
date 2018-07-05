using System;
using System.Runtime.InteropServices;
using log4net;

namespace Vji.Util {
    public interface ComWrapper<TReference> : IDisposable {
        TReference Reference { get; }
    }
}

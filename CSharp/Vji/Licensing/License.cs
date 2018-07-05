using System;
using System.Collections.Generic;

namespace Vji.Licensing {
  
    public interface License {

        bool Obtained { get; }

        void Obtain();

        void Release();

        void RunUnder(Action code);
    }
}

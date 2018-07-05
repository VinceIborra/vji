using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Conditions {

    // TODO: VJI: Use one of the standard Func delegates
    public delegate void TheCode();

    public interface Condition {

        void Setup();
        void Teardown();

        void RunUnder(TheCode theCode);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public interface Output {
        void Present(ModelAndView modelAndView);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public interface ModelAndView {
        IDictionary<string, Object> Model { get; }
        string ViewName { get; }
    }
}

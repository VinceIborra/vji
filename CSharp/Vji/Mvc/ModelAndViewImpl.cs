using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public class ModelAndViewImpl : ModelAndView {
        public IDictionary<string, object> Model { set; get; }
        public string ViewName { set; get; }
    }
}

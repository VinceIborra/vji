﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public interface Command {
        ModelAndView Process(Controller controller);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;

namespace Vji.Chess.Mvc {
    public interface ChessController : Controller {
        
        ModelAndView ProcessMoveCommand(MoveCommand command);
    }
}

using System;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {

    public class MoveCommandImpl : MoveCommand {
        
        public Move Move { set; get; }
        
        public ModelAndView Process(Controller controller) {
            return ((ChessController) controller).ProcessMoveCommand(this);
        }

    }
}

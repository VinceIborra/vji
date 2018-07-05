using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {
    public class ChessControllerImpl : ControllerImpl, ChessController {

        public Vji.Chess.Mvc.Factory Factory { set; get; }
        public Board Board { set; get; }

        private IDictionary<string, object> BoardAsModel() {
            IDictionary<string, object> model = new Dictionary<string, object>();
            model["Board"] = Board;
            return model;
        }

        public override ModelAndView ProcessStartCommand(StartCommand command) {
            Board.ArrangePieces();
            return this.Factory.NewModelAndView(this.BoardAsModel(), "StartBoardView");
        }

        public override ModelAndView ProcessFinishCommand(FinishCommand command) {
            return this.Factory.NewModelAndView(this.BoardAsModel(), "BoardView");
        }
        
        public override ModelAndView ProcessUnknownCommand(UnknownCommand command) {
            IDictionary<string, object> model = this.BoardAsModel();
            model["Comment"] = command.Comment;
            return this.Factory.NewModelAndView(model, "UnknownCommandView");
        }
        
        public ModelAndView ProcessMoveCommand(MoveCommand command) {
            this.Board.PerformMove(command.Move);
            return this.Factory.NewModelAndView(this.BoardAsModel(), "BoardView");
        }
    }
}

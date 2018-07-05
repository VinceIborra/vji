using System;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {

    public class FactoryImpl : Vji.Mvc.FactoryImpl, Vji.Chess.Mvc.Factory {
        
        public MoveCommand NewMoveCommand(Move move) {
            MoveCommandImpl command = new MoveCommandImpl();
            command.Move = move;
            return command;
        }
    }
}

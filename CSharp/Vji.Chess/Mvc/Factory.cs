using System;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {

    public interface Factory : Vji.Mvc.Factory {
        MoveCommand NewMoveCommand(Move move);
    }
}

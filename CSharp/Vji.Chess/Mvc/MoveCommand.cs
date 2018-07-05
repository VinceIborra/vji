using System;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {

    public interface MoveCommand : Command {
        Move Move { get; }
    }
}

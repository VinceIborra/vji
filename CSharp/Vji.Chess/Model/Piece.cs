using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public interface Piece {
        Colour Colour { get; }
        Type PieceType { get; }
    }
}

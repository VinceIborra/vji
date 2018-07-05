using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public class PieceImpl : Piece {
        public Colour Colour { set; get; }
        public Type PieceType { set; get; }
    }
}

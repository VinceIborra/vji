using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public interface Board {
        
        Location GetLocationAt(File file, Rank rank);

        Piece GetPieceAt(File file, Rank rank);

        void ArrangePieces();
        
        void PerformMove(Move move);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public interface Factory {

        Location NewLocation(Shade shade);

        Pawn NewPawn(Colour colour);

        Rook NewRook(Colour colour);

        Knight NewKnight(Colour colour);

        Bishop NewBishop(Colour colour);

        Queen NewQueen(Colour colour);

        King NewKing(Colour colour);
        
        Move NewMove(Type pieceType, File fromFile, Rank fromRank, File toFile, Rank toRank, bool capture);
    }
}

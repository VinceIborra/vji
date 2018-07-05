using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public class FactoryImpl : Vji.Chess.Model.Factory {

        public Location NewLocation(Shade shade) {
            LocationImpl location = new LocationImpl();
            location.Shade = shade;
            return location;
        }

        public Pawn NewPawn(Colour colour) {
            PawnImpl pawn = new PawnImpl();
            pawn.Colour = colour;
            pawn.PieceType = typeof(Pawn);
            return pawn;
        }

        public Rook NewRook(Colour colour) {
            RookImpl rook = new RookImpl();
            rook.Colour = colour;
            rook.PieceType = typeof(Rook);
            return rook;
        }

        public Knight NewKnight(Colour colour) {
            KnightImpl knight = new KnightImpl();
            knight.Colour = colour;
            knight.PieceType = typeof(Knight);
            return knight;
        }

        public Bishop NewBishop(Colour colour) {
            BishopImpl bishop = new BishopImpl();
            bishop.Colour = colour;
            bishop.PieceType = typeof(Bishop);
            return bishop;
        }

        public Queen NewQueen(Colour colour) {
            QueenImpl queen = new QueenImpl();
            queen.Colour = colour;
            queen.PieceType = typeof(Queen);
            return queen;
        }

        public King NewKing(Colour colour) {
            KingImpl king = new KingImpl();
            king.Colour = colour;
            king.PieceType = typeof(King);
            return king;
        }
        
        public Move NewMove(Type pieceType, File fromFile, Rank fromRank, File toFile, Rank toRank, bool capture) {
            MoveImpl move = new MoveImpl();
            move.Type = pieceType;
            move.FromFile = fromFile;
            move.FromRank = fromRank;
            move.ToFile = toFile;
            move.ToRank = toRank;
            move.Capture = capture;
            return move;
        }
    }
}

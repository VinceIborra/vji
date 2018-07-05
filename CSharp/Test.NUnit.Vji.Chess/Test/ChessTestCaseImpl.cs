using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.Chess.Model;
using Vji.NUnit.Std.Test;

namespace Vji.Chess {

    [TestFixture]
    [BootstrapSpring]
    public class ChessTestCaseImpl : NUnitStdTestCaseImpl {

        protected Vji.Chess.Model.Factory ChessModelFactory {
            get {
                return (Vji.Chess.Model.Factory) this.Ctx.GetObject("ChessModelFactory");
            }
        }

        protected Vji.Chess.Mvc.Factory ChessMvcFactory {
            get {
                return (Vji.Chess.Mvc.Factory) this.Ctx.GetObject("ChessMvcFactory");
            }
        }
        
        protected Board Board {
            get {
                return (Board) this.Ctx.GetObject("Board");
            }
        }
        
        protected Board ArrangedBoard {
            get {
                this.Board.ArrangePieces();
                return this.Board;
            }
        }

        public void AssertPiece(Piece piece, Type type, Colour colour) {
            Assert.IsNotNull(piece);
            Assert.IsInstanceOf(type, piece);
            Assert.AreEqual(colour, piece.Colour);
        }

        public void AssertArrangedBoard(Board board) {

            AssertPiece(board.GetPieceAt(File.FileA, Rank.Rank8), typeof(Rook), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileB, Rank.Rank8), typeof(Knight), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileC, Rank.Rank8), typeof(Bishop), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileD, Rank.Rank8), typeof(Queen), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileE, Rank.Rank8), typeof(King), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileF, Rank.Rank8), typeof(Bishop), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileG, Rank.Rank8), typeof(Knight), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileH, Rank.Rank8), typeof(Rook), Colour.Black);

            AssertPiece(board.GetPieceAt(File.FileA, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileB, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileC, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileD, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileE, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileF, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileG, Rank.Rank7), typeof(Pawn), Colour.Black);
            AssertPiece(board.GetPieceAt(File.FileH, Rank.Rank7), typeof(Pawn), Colour.Black);

            foreach(Rank rank in new Rank[]{Rank.Rank6, Rank.Rank5, Rank.Rank4, Rank.Rank3}) {
                foreach (File file in File.Items) {
                    Assert.IsNull(board.GetPieceAt(file, rank));
                }
            }

            AssertPiece(board.GetPieceAt(File.FileA, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileB, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileC, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileD, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileE, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileF, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileG, Rank.Rank2), typeof(Pawn), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileH, Rank.Rank2), typeof(Pawn), Colour.White);

            AssertPiece(board.GetPieceAt(File.FileA, Rank.Rank1), typeof(Rook), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileB, Rank.Rank1), typeof(Knight), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileC, Rank.Rank1), typeof(Bishop), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileD, Rank.Rank1), typeof(Queen), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileE, Rank.Rank1), typeof(King), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileF, Rank.Rank1), typeof(Bishop), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileG, Rank.Rank1), typeof(Knight), Colour.White);
            AssertPiece(board.GetPieceAt(File.FileH, Rank.Rank1), typeof(Rook), Colour.White);
        }
    }
}

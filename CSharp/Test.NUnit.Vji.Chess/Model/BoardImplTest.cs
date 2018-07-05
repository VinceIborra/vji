using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Chess;
using Vji.Std.Test;

namespace Vji.Chess.Model {

    [TestFixture]
    //[BootstrapLog4net]
    [BootstrapSpring]
    public class BoardImplTest : ChessTestCaseImpl {

        [Test]
        public void TestSetLocationAt() {
            Factory chessModelFactory = (Factory)Ctx.GetObject("ChessModelFactory");
            Board board = (Board)Ctx.GetObject("Board");
            BoardImpl boardImpl = (BoardImpl) board;
            Location location = chessModelFactory.NewLocation(Shade.Light);
            File file = File.FileA;
            Rank rank = Rank.Rank8;
            boardImpl.SetLocationAt(location, file, rank);
            Assert.AreEqual(location, boardImpl.GetLocationAt(file, rank));
        }

        [Test]
        public void TestGetLocationAt() {
            Factory chessModelFactory = (Factory)Ctx.GetObject("ChessModelFactory");
            Board board = (Board)Ctx.GetObject("Board");
            BoardImpl boardImpl = (BoardImpl) board;
            File file = File.FileA;
            Rank rank = Rank.Rank8;
            Location location = boardImpl.GetLocationAt(file, rank);
            Assert.IsNotNull(location);
            Assert.That(location.Shade, Is.EqualTo(Shade.Light));
        }

        [Test]
        public void TestPlacePieceAt() {
            Factory chessModelFactory = (Factory) Ctx.GetObject("ChessModelFactory");
            Board board = (Board) Ctx.GetObject("Board");
            BoardImpl boardImpl = (BoardImpl) board;
            Piece piece = chessModelFactory.NewRook(Colour.Black);
            File file = File.FileA;
            Rank rank = Rank.Rank8;
            boardImpl.PlacePieceAt(piece, file, rank);
            Assert.AreEqual(piece, boardImpl.GetPieceAt(file, rank));
        }

        [Test]
        public void TestGetPieceAt() {
            Factory chessModelFactory = (Factory)Ctx.GetObject("ChessModelFactory");
            Board board = (Board)Ctx.GetObject("Board");
            BoardImpl boardImpl = (BoardImpl) board;
            Piece piece = chessModelFactory.NewRook(Colour.Black);
            File file = File.FileA;
            Rank rank = Rank.Rank8;
            boardImpl.PlacePieceAt(piece, file, rank);
            Assert.AreEqual(piece, boardImpl.GetPieceAt(file, rank));
        }

        [Test]
        public void TestArrangePieces() {
            Board board = (Board) Ctx.GetObject("Board");
            board.ArrangePieces();
            AssertArrangedBoard(board);
        }
        
        [Test] public void TestPerformMove() {
            Board board = this.ArrangedBoard;
            Piece piece = board.GetPieceAt(File.FileA, Rank.Rank7);
            Move move = this.ChessModelFactory.NewMove(typeof(Pawn), File.FileA, Rank.Rank7, File.FileA, Rank.Rank6, false);
            board.PerformMove(move);
            Assert.That(board.GetPieceAt(File.FileA, Rank.Rank6), Is.EqualTo(piece));
        }

    }
}
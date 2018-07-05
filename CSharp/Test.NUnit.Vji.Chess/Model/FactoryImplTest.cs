using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace Vji.Chess.Model {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class FactoryImplTest : NUnitStdTestCaseImpl {
        
        private Vji.Chess.Model.FactoryImpl _factoryImpl;
        
        private Vji.Chess.Model.FactoryImpl FactoryImpl {
            get {
                if (_factoryImpl == null) {
                    _factoryImpl = new Vji.Chess.Model.FactoryImpl();
                }
                return _factoryImpl;
            }
        }

        [Test]
        public void TestNewLocation() {
            Location location = this.FactoryImpl.NewLocation(Shade.Light);
            Assert.IsNotNull(location);
            Assert.IsInstanceOf(typeof(LocationImpl), location);
            Assert.That(location.Shade, Is.EqualTo(Shade.Light));
            Assert.IsNull(location.Piece);
        }

        [Test]
        public void TestNewPawn() {
            Pawn pawn = this.FactoryImpl.NewPawn(Colour.Black);
            Assert.IsNotNull(pawn);
            Assert.IsInstanceOf(typeof(PawnImpl), pawn);
            Assert.AreEqual(Colour.Black, pawn.Colour);
            Assert.That(pawn.PieceType, Is.EqualTo(typeof(Pawn)));
        }

        [Test]
        public void TestNewRook() {
            Rook rook = this.FactoryImpl.NewRook(Colour.Black);
            Assert.IsNotNull(rook);
            Assert.IsInstanceOf(typeof(RookImpl), rook);
            Assert.AreEqual(Colour.Black, rook.Colour);
            Assert.That(rook.PieceType, Is.EqualTo(typeof(Rook)));
        }

        [Test]
        public void TestNewKnight() {
            Knight knight = this.FactoryImpl.NewKnight(Colour.Black);
            Assert.IsNotNull(knight);
            Assert.IsInstanceOf(typeof(KnightImpl), knight);
            Assert.AreEqual(Colour.Black, knight.Colour);
            Assert.That(knight.PieceType, Is.EqualTo(typeof(Knight)));
        }

        [Test]
        public void TestNewBishop() {
            Bishop bishop = this.FactoryImpl.NewBishop(Colour.Black);
            Assert.IsNotNull(bishop);
            Assert.IsInstanceOf(typeof(BishopImpl), bishop);
            Assert.AreEqual(Colour.Black, bishop.Colour);
            Assert.That(bishop.PieceType, Is.EqualTo(typeof(Bishop)));
        }

        [Test]
        public void TestNewQueen() {
            Queen queen = this.FactoryImpl.NewQueen(Colour.Black);
            Assert.IsNotNull(queen);
            Assert.IsInstanceOf(typeof(QueenImpl), queen);
            Assert.AreEqual(Colour.Black, queen.Colour);
            Assert.That(queen.PieceType, Is.EqualTo(typeof(Queen)));
        }

        [Test]
        public void TestNewKing() {
            King king = this.FactoryImpl.NewKing(Colour.Black);
            Assert.IsNotNull(king);
            Assert.IsInstanceOf(typeof(KingImpl), king);
            Assert.AreEqual(Colour.Black, king.Colour);
            Assert.That(king.PieceType, Is.EqualTo(typeof(King)));
        }
        
        [Test]
        public void TestNewMove() {
            Move move = this.FactoryImpl.NewMove(
                typeof(Pawn),
                File.FileA, Rank.Rank7,
                File.FileA, Rank.Rank6,
                false
            );
            Assert.That(move, Is.Not.Null);
            Assert.That(move, Is.InstanceOf(typeof(MoveImpl)));
            Assert.That(move.Type, Is.EqualTo(typeof(Pawn)));
            Assert.That(move.FromFile, Is.EqualTo(File.FileA));
            Assert.That(move.FromRank, Is.EqualTo(Rank.Rank7));
            Assert.That(move.ToFile, Is.EqualTo(File.FileA));
            Assert.That(move.ToRank, Is.EqualTo(Rank.Rank6));
            Assert.That(move.Capture, Is.False);
        }

    }
}
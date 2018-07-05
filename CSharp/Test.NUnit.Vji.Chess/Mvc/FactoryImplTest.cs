using System;
using NUnit.Framework;
using Vji.Chess.Model;
using Vji.Chess;


namespace Vji.Chess.Mvc {

    [TestFixture]
    public class FactoryImplTest : ChessTestCaseImpl {

        [Test] public void TestMoveCommand() {
            Move move = this.ChessModelFactory.NewMove(typeof(Pawn), File.FileA, Rank.Rank7, File.FileA, Rank.Rank6, false);
            Vji.Chess.Mvc.FactoryImpl factoryImpl = new Vji.Chess.Mvc.FactoryImpl();
            MoveCommand moveCommand = factoryImpl.NewMoveCommand(move);
            Assert.That(moveCommand, Is.Not.Null);
            Assert.That(moveCommand, Is.InstanceOf(typeof(MoveCommandImpl)));
            Assert.That(moveCommand.Move, Is.EqualTo(move));
        }
    }
}

using System;
using NUnit.Framework;
using Vji.Mvc;
using Vji.Std.Test;
using Vji.Chess.Model;
using Vji.Chess;

namespace Vji.Chess.Mvc {
    
    [TestFixture]
    public class ChessNotationParserImplTest : ChessTestCaseImpl {

        private ChessNotationParserImpl _chessNotationParserImpl;
        
        private ChessNotationParserImpl ChessNotationParserImpl {
            get {
                if (_chessNotationParserImpl == null) {
                    _chessNotationParserImpl = new ChessNotationParserImpl();
                    _chessNotationParserImpl.ChessFactory = this.ChessModelFactory;
                    _chessNotationParserImpl.MvcFactory = this.ChessMvcFactory;
                }
                return _chessNotationParserImpl;
            }
        }
        
        [Test] public void TestParse_ForExitCommand() {
            Command command = this.ChessNotationParserImpl.Parse("exit");
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(FinishCommand)));
        }
        
        [Test] public void TestParse_ForMoveCommand() {
            Command command = this.ChessNotationParserImpl.Parse("pa2a3");
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(MoveCommand)));
            MoveCommand moveCommand = (MoveCommand) command;
            Assert.That(moveCommand.Move, Is.Not.Null);
            Assert.That(moveCommand.Move.Type, Is.EqualTo(typeof(Pawn)));
            Assert.That(moveCommand.Move.FromRank, Is.EqualTo(Rank.Rank2));
            Assert.That(moveCommand.Move.FromFile, Is.EqualTo(File.FileA));
            Assert.That(moveCommand.Move.ToRank, Is.EqualTo(Rank.Rank3));
            Assert.That(moveCommand.Move.ToFile, Is.EqualTo(File.FileA));
            Assert.That(moveCommand.Move.Capture, Is.False);
        }

        //    @Test
//    public void testParseArrageCommand() {
//        String str = "arrange";
//        Command command = getParser().parse(str);
//        assertNotNull(command);
//        assertTrue(command instanceof ArrangeCommand);
//    }
        
    }
}

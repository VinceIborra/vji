using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.Mvc;
using Vji.Chess.Model;
using Vji.Chess;

namespace Vji.Chess.Mvc {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class ChessControllerImplTest : ChessTestCaseImpl {
        
        private Vji.Chess.Mvc.Factory MvcFactory {
            get { return (Factory) Ctx.GetObject("ChessMvcFactory"); }
        }
        
        private ChessControllerImpl ChessControllerImpl {
            get {
                ChessControllerImpl controller = new ChessControllerImpl();
                controller.Factory = this.MvcFactory;
                controller.Board = this.Board;
                return controller;
            }
        }
        
        private void AssertValidModelAndView(ModelAndView modelAndView) {
            Assert.IsNotNull(modelAndView);
            Assert.IsNotNull(modelAndView.ViewName);
            Assert.IsNotNull(modelAndView.Model);
        }

        [Test] public void TestProcessStartCommand() {
            StartCommand startCommand = this.MvcFactory.NewStartCommand();
            ModelAndView modelAndView = this.ChessControllerImpl.ProcessStartCommand(startCommand);
            this.AssertValidModelAndView(modelAndView);
            IDictionary<string, object> model = modelAndView.Model;
            Assert.AreEqual("StartBoardView", modelAndView.ViewName);
            Assert.IsTrue(model.ContainsKey("Board"));
            object boardObject = model["Board"];
            Assert.IsInstanceOf(typeof(Board), boardObject);
            Board board = (Board) boardObject;
            AssertArrangedBoard(board);
        }
        
        [Test] public void TestProcessFinishCommand() {
            FinishCommand finishCommand = this.MvcFactory.NewFinishCommand();
            ModelAndView modelAndView = this.ChessControllerImpl.ProcessFinishCommand(finishCommand);
            this.AssertValidModelAndView(modelAndView);
            IDictionary<string, object> model = modelAndView.Model;
            Assert.AreEqual("BoardView", modelAndView.ViewName);
            Assert.IsTrue(model.ContainsKey("Board"));
            object boardObject = model["Board"];
            Assert.IsInstanceOf(typeof(Board), boardObject);
        }

        [Test] public void TestProcessUnknownCommand() {
            UnknownCommand unknownCommand = this.MvcFactory.NewUnknownCommand("a comment str");
            ModelAndView modelAndView = this.ChessControllerImpl.ProcessUnknownCommand(unknownCommand);
            this.AssertValidModelAndView(modelAndView);
            IDictionary<string, object> model = modelAndView.Model;
            Assert.AreEqual("UnknownCommandView", modelAndView.ViewName);
            Assert.IsTrue(model.ContainsKey("Board"));
            Assert.IsTrue(model.ContainsKey("Comment"));
            object boardObject = model["Board"];
            Assert.IsInstanceOf(typeof(Board), boardObject);
            object commentObject = model["Comment"];
            Assert.That(commentObject, Is.InstanceOf(typeof(string)));
        }
        
        [Test] public void TestProcessMoveCommand() {
            Board board = this.ArrangedBoard;
            Move move = this.ChessModelFactory.NewMove(typeof(Pawn), File.FileA, Rank.Rank7, File.FileA, Rank.Rank6, false);
            MoveCommand moveCommand = this.MvcFactory.NewMoveCommand(move);
            ModelAndView modelAndView = this.ChessControllerImpl.ProcessMoveCommand(moveCommand);
            this.AssertValidModelAndView(modelAndView);
            IDictionary<string, object> model = modelAndView.Model;
            Assert.AreEqual("BoardView", modelAndView.ViewName);
            Assert.IsTrue(model.ContainsKey("Board"));
            object boardObject = model["Board"];
            Assert.IsInstanceOf(typeof(Board), boardObject);
            board = (Board) boardObject;
            Location location = board.GetLocationAt(File.FileA, Rank.Rank6);
            Assert.That(location.Piece, Is.Not.Null);
            Assert.That(location.Piece.PieceType, Is.EqualTo(typeof(Pawn)));
        }

    }
}
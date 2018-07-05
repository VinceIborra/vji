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
    public class BoardViewImplTest : ChessTestCaseImpl {

        private IDictionary<string, object> Model { set; get; }
        private View BoardView { set; get; }
        private BoardViewImpl BoardViewImpl { set; get; }

        [SetUp]
        public void TestInitialize() {

            // Bootstrapping
            base.Initialize();

            // Setup model
            Model = new Dictionary<string, object>();
            Model.Add("Board", Board);

            // Setup view
            BoardView = (View) Ctx.GetObject("BoardView");
            BoardViewImpl = (BoardViewImpl) BoardView;
        }

        [Test]
        public void TestRenderBoard() {
            string str = BoardViewImpl.RenderBoard(this.ArrangedBoard);
            Assert.AreEqual(
                "     A   B   C   D   E   F   G   H\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "8  | R |-N-| B |-Q-| K |-B-| N |-R-|\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "7  |-P-| P |-P-| P |-P-| P |-P-| P |\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "6  |   |---|   |---|   |---|   |---|\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "5  |---|   |---|   |---|   |---|   |\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "4  |   |---|   |---|   |---|   |---|\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "3  |---|   |---|   |---|   |---|   |\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "2  | p |-p-| p |-p-| p |-p-| p |-p-|\n" +
                "   +---+---+---+---+---+---+---+---+\n" +
                "1  |-r-| n |-b-| q |-k-| b |-n-| r |\n" +
                "   +---+---+---+---+---+---+---+---+\n",
                str
            );
        }

        [Test]
        public void TestRenderPrompt() {
            string str = BoardViewImpl.RenderPrompt();
            Assert.AreEqual("> ", str);
        }
    }
}

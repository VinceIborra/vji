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
    public class StartBoardViewImplTest : ChessTestCaseImpl {

        private IDictionary<string, object> Model { set; get; }
        private View StartBoardView { set; get; }
        private StartBoardViewImpl StartBoardViewImpl { set; get; }

        [SetUp]
        public void TestInitialize() {

            // Bootstrapping
            base.Initialize();

            // Setup model
            Model = new Dictionary<string, object>();
            Model.Add("Board", Board);

            // Setup view
            StartBoardView = (View) Ctx.GetObject("StartBoardView");
            StartBoardViewImpl = (StartBoardViewImpl) StartBoardView;
        }

        [Test]
        public void TestRenderStartPreamble() {
            string str = StartBoardViewImpl.RenderStartPreamble();
            Assert.AreEqual(
                "This is the chess game implemented in C#\n" +
                "Commands:\n" +
                "  Move A Piece:\n" +
                "    <piece><from_file><from_rank>[<capture>]<to_file><to_rank>\n" +
                "\n" +
                "    piece   - p,r,n,b,q,k\n" +
                "    file    - a,b,c,d,e,f,g,h\n" +
                "    rank    - 1,2,3,4,5,6,7,8\n" +
                "    capture - x\n" +
                "\n" +
                "  Other:\n" +
                "    help - Display the list of commands\n" +
                "    exit - Exit the game\n",
                str
            );
        }

    }
}

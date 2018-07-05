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
    public class UnknownCommandViewImplTest : ChessTestCaseImpl {

        [Test]
        public void TestRender() {
            
            Board board = this.ArrangedBoard;

            IDictionary<string, object> model = new Dictionary<string, object>();
            model.Add("Board", board);
            model.Add("Comment", "a comment string");
            
            UnknownCommandViewImpl view = new UnknownCommandViewImpl();
            string str = view.Render(model);
            
            Assert.That(str, Is.EqualTo(
                "An unknown command was entered - a comment string\n" +
                "Please try again\n" +
                "\n" +
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
                "   +---+---+---+---+---+---+---+---+\n" +
                "> "
            ));
        }
    }
}

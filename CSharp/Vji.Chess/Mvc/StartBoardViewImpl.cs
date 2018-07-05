using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {
    public class StartBoardViewImpl : BoardViewImpl, View {

        public string RenderStartPreamble() {
            return "This is the chess game implemented in C#\n" +
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
                   "    exit - Exit the game\n";
        }

        public new string Render(IDictionary<string, Object> model) {
            this.AssertValidModel(model);
            this.AssertBoardInModel(model);
            return this.RenderStartPreamble()
                 + this.RenderBoard((Board) model["Board"])
                 + this.RenderPrompt();
        }
    }
}

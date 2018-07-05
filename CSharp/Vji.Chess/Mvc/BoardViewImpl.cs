using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Exceptions;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {
    public class BoardViewImpl : View {

        protected void AssertValidModel(IDictionary<string, Object> model) {
            if (model == null) {
                throw new InternalErrorException("Expected model to not be null.");
            }
        }
        
        protected void AssertBoardInModel(IDictionary<string, Object> model) {
            if (!model.ContainsKey("Board") || !(model["Board"] is Board)) {
                throw new InternalErrorException(
                    "Expected component \"Board\" to be present in the model - " + model + "."
                );
            }
        }

        public string RenderBoard(Board board) {
            String str = "";
            str = str + "     A   B   C   D   E   F   G   H\n";
            str = str + "   +---+---+---+---+---+---+---+---+\n";
            foreach(Rank rank in Rank.Items.Reverse()) {
              str = str + rank.Value + "  |";
              foreach (File file in File.Items) {
                Location location = board.GetLocationAt(file, rank);
                if (location.Shade == Shade.Light) {
                  str = str + " ";
                }
                else {
                  str = str + "-";
                  }
                Piece piece = location.Piece;
                String pieceStr = "";
                if (piece == null)
                    pieceStr = (location.Shade == Shade.Dark)? "-":" ";
                else if (piece is Rook)
                    pieceStr = (piece.Colour == Colour.Black)? "R":"r";
                else if (piece is Knight)
                    pieceStr = (piece.Colour == Colour.Black)? "N":"n";
                else if (piece is Bishop)
                    pieceStr = (piece.Colour == Colour.Black)? "B":"b";
                else if (piece is Queen)
                    pieceStr = (piece.Colour == Colour.Black)? "Q":"q";
                else if (piece is King)
                    pieceStr = (piece.Colour == Colour.Black)? "K":"k";
                else if (piece is Pawn)
                    pieceStr = (piece.Colour == Colour.Black)? "P":"p";
                str = str + pieceStr;
                if (location.Shade == Shade.Light)
                  str = str + " |";
                else
                  str = str + "-|";
              }
              str = str + "\n";
              str = str + "   +---+---+---+---+---+---+---+---+\n";
            }
            return str;
        }

        public string RenderPrompt() {
            return "> ";
        }

        public string Render(IDictionary<string, Object> model) {
            this.AssertValidModel(model);
            this.AssertBoardInModel(model);
            return RenderBoard((Board) model["Board"]) + RenderPrompt();
        }
    }
}

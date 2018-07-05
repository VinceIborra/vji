package vji.chess.mvc;

import java.util.*;
import vji.mvc.View;
import vji.chess.*;

/**
 *
 * @author vji
 */
public class BoardViewImpl implements View {


    public String renderBoard(Board board) {
        String str = "\n";
        str = str + "     A   B   C   D   E   F   G   H\n";
        str = str + "   +---+---+---+---+---+---+---+---+\n";
        List<Rank> rankList = new ArrayList(Arrays.asList(Rank.values));
        Collections.reverse(rankList);
        for (Rank rank : rankList) {
          str = str + rank.getValue() + "  |";
          for (File file : File.values) {
            Square square = board.getSquareAt(file, rank);
            if (square.getShade() == Shade.Light) {
              str = str + " ";
            }
            else {
              str = str + "-";
              }
            Piece piece = square.getPiece();
            String pieceStr = "";
            if (piece == null)
                pieceStr = (square.getShade() == Shade.Dark)? "-":" ";
            else if (piece instanceof Rook)
                pieceStr = (piece.getColour() == Colour.Black)? "R":"r";
            else if (piece instanceof Knight)
                pieceStr = (piece.getColour() == Colour.Black)? "N":"n";
            else if (piece instanceof Bishop)
                pieceStr = (piece.getColour() == Colour.Black)? "B":"b";
            else if (piece instanceof Queen)
                pieceStr = (piece.getColour() == Colour.Black)? "Q":"q";
            else if (piece instanceof King)
                pieceStr = (piece.getColour() == Colour.Black)? "K":"k";
            else if (piece instanceof Pawn)
                pieceStr = (piece.getColour() == Colour.Black)? "P":"p";
            str = str + pieceStr;
            if (square.getShade() == Shade.Light)
              str = str + " |";
            else
              str = str + "-|";
          }
          str = str + "\n";
          str = str + "   +---+---+---+---+---+---+---+---+\n";
        }
        str = str + "\n";
        return str;
    }

    public String renderPrompt() {
        return "> ";
    }

    public String render(Object model) {
        if (model instanceof Board) {
            return renderBoard((Board) model) + renderPrompt();
        }
        return "";
    }

}

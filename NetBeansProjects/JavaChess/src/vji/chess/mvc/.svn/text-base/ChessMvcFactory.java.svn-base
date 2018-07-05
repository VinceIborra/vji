package vji.chess.mvc;

import vji.mvc.*;
import vji.chess.*;

/**
 *
 * @author vji
 */
public interface ChessMvcFactory extends vji.mvc.Factory {

    ChessController newChessController(Board board);
    Parser newParser(ChessFactory chessFactory);
    View newBoardView();
    View newStartBoardView();

    UnknownCommand newUnknownCommand(String message);
    ArrangeCommand newArrangeCommand();
    MoveCommand newMoveCommand(Move move);
}

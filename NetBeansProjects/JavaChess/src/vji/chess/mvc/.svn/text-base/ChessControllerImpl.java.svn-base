package vji.chess.mvc;
import vji.mvc.*;
import vji.chess.*;

/**
 *
 * @author vji
 */
public class ChessControllerImpl implements ChessController {

    private ChessMvcFactory _factory;
    private Board _board;

    public void setFactory(ChessMvcFactory factory) { _factory = factory; }
    public ChessMvcFactory getFactory() { return _factory; }

    public void setBoard(Board board) { _board = board; }
    public Board getBoard() { return _board; }

    public ModelAndView process(Command command) {
        return command.process(this);
    }

    public ModelAndView processAppStartCommand(AppStartCommand command) {
        getBoard().arrangePieces();
        return getFactory().newModelAndView(
            getBoard(),
            "startBoardView"
        );
    }

    public ModelAndView processAppEndCommand(AppEndCommand command) {
        return getFactory().newModelAndView(
            getBoard(),
            "boardView"
        );
    }

    @Override
    public ModelAndView processArrangeCommand(ArrangeCommand command) {
        getBoard().arrangePieces();
        return getFactory().newModelAndView(
            getBoard(),
            "boardView"
        );
    }

    @Override
    public ModelAndView processMoveCommand(MoveCommand command) {
        getBoard().movePiece(command.getMove());
        return getFactory().newModelAndView(
            getBoard(),
            "boardView"
        );
    }
}

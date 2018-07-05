package vji.chess.mvc;

import vji.chess.Move;
import vji.mvc.Controller;
import vji.mvc.ModelAndView;

/**
 *
 * @author vji
 */
public class MoveCommandImpl implements MoveCommand {

    private Move _move;

    public void setMove(Move move) { _move = move; }

    @Override
    public Move getMove() { return _move; }

    @Override
    public ModelAndView process(Controller controller) {
        return ((ChessController) controller).processMoveCommand(this);
    }

}

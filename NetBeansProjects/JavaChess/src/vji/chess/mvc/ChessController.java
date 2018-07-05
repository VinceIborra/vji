package vji.chess.mvc;
import vji.mvc.*;

/**
 *
 * @author vji
 */
public interface ChessController extends Controller {
    ModelAndView processArrangeCommand(ArrangeCommand command);
    ModelAndView processMoveCommand(MoveCommand command);
}

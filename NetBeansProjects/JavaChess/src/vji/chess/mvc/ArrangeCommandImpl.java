package vji.chess.mvc;

import vji.mvc.Controller;
import vji.mvc.ModelAndView;

/**
 *
 * @author vji
 */
public class ArrangeCommandImpl implements ArrangeCommand {

    public ModelAndView process(Controller controller) {
        return ((ChessController) controller).processArrangeCommand(this);
    }
}

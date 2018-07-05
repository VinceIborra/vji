package vji.mvc;
import vji.chess.mvc.ChessControllerImpl;
import vji.mvc.*;

/**
 *
 * @author vji
 */
public class AppStartCommandImpl implements AppStartCommand{
    public ModelAndView process(Controller controller) {
        return ((Controller) controller).processAppStartCommand(this);
    }
}

package vji.chess.mvc;

import vji.mvc.Controller;
import vji.mvc.ModelAndView;

/**
 *
 * @author vji
 */
public class UnknownCommandImpl implements UnknownCommand {

    private String _commandString;

    public void setCommandString(String commandString) { _commandString = commandString; }

    public String getCommandString() { return _commandString; }

    public ModelAndView process(Controller controller) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

}

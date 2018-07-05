package vji.chess.mvc;

import java.util.*;
import vji.mvc.*;

/**
 *
 * @author vji
 */
public class MockChessControllerImpl implements ChessController {

    private List<Command> _commandsProcessed;
    private boolean _boardArranged;

    private void setCommandsProcessed(List<Command> commands) { _commandsProcessed = commands; }
    private void setBoardArranged(boolean boardArranged) { _boardArranged = true; }

    public List<Command> getCommandsProcessed() { return _commandsProcessed; }
    public boolean isBoardArranged() { return _boardArranged; }

    public MockChessControllerImpl() {
        setCommandsProcessed(new ArrayList());
    }

    @Override
    public ModelAndView process(Command command) {
        return command.process(this);
    }

    @Override
    public ModelAndView processAppStartCommand(AppStartCommand command) {
        getCommandsProcessed().add(command);
        return null;
    }

    @Override
    public ModelAndView processArrangeCommand(ArrangeCommand command) {
        getCommandsProcessed().add(command);
        setBoardArranged(true);
        return null;
    }

    @Override
    public ModelAndView processAppEndCommand(AppEndCommand command) {
        getCommandsProcessed().add(command);
        return null;
    }

    @Override
    public ModelAndView processMoveCommand(MoveCommand command) {
        getCommandsProcessed().add(command);
        return null;
    }
}

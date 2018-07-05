/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package multidispatch;
import java.util.*;

/**
 *
 * @author vji
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ProcessorImpl processor = new ProcessorImpl();
        TurnLeftCommand turnLeftCommand = new TurnLeftCommandImpl();
        TurnRightCommand turnRightCommand = new TurnRightCommandImpl();
        List<Command> commands = new ArrayList<Command>();
        commands.add(turnLeftCommand);
        commands.add(turnRightCommand);
        for (Command command : commands) {
            processor.process(command);
        }
    }

}

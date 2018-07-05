/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package multidispatch;

/**
 *
 * @author vji
 */
public class ProcessorImpl implements Processor {

    public void process(Command command) {
        command.process(this);
    }

    public void process(TurnLeftCommand command) {
        System.out.println("Left turn.");
    }

    public void process(TurnRightCommand command) {
        System.out.println("Right turn.");
    }

}

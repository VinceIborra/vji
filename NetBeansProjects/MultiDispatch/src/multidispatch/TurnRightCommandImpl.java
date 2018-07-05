/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package multidispatch;

/**
 *
 * @author vji
 */
public class TurnRightCommandImpl implements TurnRightCommand {

    public void process(Processor processor) {
        processor.process(this);
    }

}

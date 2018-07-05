/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package multidispatch;

/**
 *
 * @author vji
 */
public interface Processor {
  public void process(Command command);
  public void process(TurnLeftCommand command);
  public void process(TurnRightCommand command);
}

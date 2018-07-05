/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package multidispatch;

/**
 *
 * @author vji
 */
public interface Command {
  public void process(Processor processor);
}

package vji.mvc;

/**
 *
 * @author vji
 */
public interface Controller {
    
    ModelAndView process(Command command);

    ModelAndView processAppStartCommand(AppStartCommand command);
    ModelAndView processAppEndCommand(AppEndCommand command);
}

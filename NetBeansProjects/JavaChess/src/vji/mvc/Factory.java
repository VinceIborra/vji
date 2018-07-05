package vji.mvc;

/**
 *
 * @author vji
 */
public interface Factory {
    AppStartCommand newAppStartCommand();
    AppEndCommand newAppEndCommand();
    ModelAndView newModelAndView(Object model, String viewName);
}

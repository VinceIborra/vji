package vji.mvc;

/**
 *
 * @author vji
 */
public class FactoryImpl implements Factory {

    public AppStartCommand newAppStartCommand() {
        AppStartCommandImpl command = new AppStartCommandImpl();
        return command;
    }

    @Override
    public AppEndCommand newAppEndCommand() {
        AppEndCommandImpl command = new AppEndCommandImpl();
        return command;
    }

    public ModelAndView newModelAndView(Object model, String viewName) {
        ModelAndViewImpl modelAndView = new ModelAndViewImpl();
        modelAndView.setModel(model);
        modelAndView.setViewName(viewName);
        return modelAndView;
    }

}

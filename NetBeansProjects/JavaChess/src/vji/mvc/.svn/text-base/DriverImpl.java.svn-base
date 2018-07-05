package vji.mvc;

/**
 *
 * @author vji
 */
public class DriverImpl implements Driver {

    private Factory _factory;
    private Input _input;
    private Output _output;
    private Parser _parser;
    private Controller _controller;
    private ViewResolver _viewResolver;

    public void setFactory(Factory factory) { _factory = factory; }
    public Factory getFactory() { return _factory; }

    public void setInput(Input input) { _input = input; }
    public Input getInput() { return _input; }

    public void setOutput(Output output) { _output = output; }
    public Output getOutput() { return _output; }

    public void setParser(Parser parser) { _parser = parser; }
    public Parser getParser() { return _parser; }

    public void setController(Controller controller) { _controller = controller; }
    public Controller getController() { return _controller; }

    public void setViewResolver(ViewResolver viewResolver) { _viewResolver = viewResolver; }
    public ViewResolver getViewResolver() { return _viewResolver; }

    public void run() {
        int status = 0;
        while (status != 2) {
            Command command = null;
            if (status == 0) {
                status = 1;
                command = getFactory().newAppStartCommand();
            }
            else if (status == 1) {
                String inputText = getInput().collect();
                command = getParser().parse(inputText);
            }
            ModelAndView modelAndView = getController().process(command);
            View view = getViewResolver().resolve(modelAndView.getViewName());
            String outputText = view.render(modelAndView.getModel());
            getOutput().present(outputText);
            if (command instanceof AppEndCommand) {
                status = 2;
            }
        }
    }
}

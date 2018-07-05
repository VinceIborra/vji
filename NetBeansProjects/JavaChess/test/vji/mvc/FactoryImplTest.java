package vji.mvc;

import vji.chess.mvc.ChessControllerImpl;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class FactoryImplTest {

    private Factory _factory;

    private void setFactory(Factory factory) { _factory = factory; }
    private Factory getFactory() { return _factory; }

    @Before
    public void setUp() {
        setFactory(new FactoryImpl());
    }

    @Test
    public void testNewAppStartCommand() {
        AppStartCommand command = getFactory().newAppStartCommand();
        assertNotNull(command);
        assertTrue(command instanceof AppStartCommandImpl);
    }

    @Test
    public void testNewAppEndCommand() {
        AppEndCommand command = getFactory().newAppEndCommand();
        assertNotNull(command);
        assertTrue(command instanceof AppEndCommandImpl);
    }

    @Test
    public void testNewModelAndView() {
        String model = "some misc model object";
        String viewName = "a_standard_view_name";
        ModelAndView modelAndView = getFactory().newModelAndView(model, viewName);
        assertNotNull(modelAndView);
        assertTrue(modelAndView instanceof ModelAndViewImpl);
        assertEquals(model, modelAndView.getModel());
        assertEquals(viewName, modelAndView.getViewName());
    }
}
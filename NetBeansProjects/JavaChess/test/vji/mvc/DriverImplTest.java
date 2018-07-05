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
public class DriverImplTest {

    /**
     * Test of setController method, of class DriverImpl.
     */
    @Test
    public void testSetController() {
        System.out.println("setController");
        Controller controller = new ChessControllerImpl();
        DriverImpl instance = new DriverImpl();
        instance.setController(controller);
        assertEquals(controller, instance.getController());
    }

    /**
     * Test of getController method, of class DriverImpl.
     */
    @Test
    public void testGetController() {
        System.out.println("getController");
        Controller controller = new ChessControllerImpl();
        DriverImpl instance = new DriverImpl();
        instance.setController(controller);
        assertEquals(controller, instance.getController());
    }

}
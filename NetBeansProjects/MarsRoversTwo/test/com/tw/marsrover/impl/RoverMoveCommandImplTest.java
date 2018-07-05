package com.tw.marsrover.impl;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverMoveCommandImplTest {

    public RoverMoveCommandImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Test
    public void testSomeMethod() {
        // Nothing to do
        assert(true);
    }

    /**
     * Test of equals method, of class RoverMoveCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverMoveCommandImpl command1 = new RoverMoveCommandImpl();
        RoverMoveCommandImpl command2 = new RoverMoveCommandImpl();
        assertEquals(command1, command2);
    }

    /**
     * Test of process method, of class RoverMoveCommandImpl.
     */
    @Test
    public void testProcess() {

        // Setup
        System.out.println("process");
        Factory factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        RoverLogger logger = factory.newRoverLogger("test.log");
        RoverController roverController = factory.newRoverController(factory, plateau, repository, logger);
        PlateauChangeCommand plateauChangeCommand = factory.newPlateauChangeCommand(5, 5);
        RoverStartCommand roverStartCommand = factory.newRoverStartCommand("bob", 1, 1, Orientation.North);
        roverController.processCommand(plateauChangeCommand);
        roverController.processCommand(roverStartCommand);

        // Test
        RoverMoveCommandImpl instance = new RoverMoveCommandImpl();
        roverController.processCommand(instance);
        assertNotNull(repository.getCurrentRover());
        assertEquals(1, repository.getCurrentRover().getPositionAndOrientation().getX());
        assertEquals(2, repository.getCurrentRover().getPositionAndOrientation().getY());
        assertEquals(Orientation.North, repository.getCurrentRover().getPositionAndOrientation().getOrientation());
    }

}
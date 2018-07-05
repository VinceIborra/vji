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
public class RoverTurnRightCommandImplTest {

    public RoverTurnRightCommandImplTest() {
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
     * Test of equals method, of class RoverTurnRightCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverTurnRightCommandImpl command1 = new RoverTurnRightCommandImpl();
        RoverTurnRightCommandImpl command2 = new RoverTurnRightCommandImpl();
        assertEquals(command1, command2);
    }

    /**
     * Test of process method, of class RoverTurnRightCommandImpl.
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
        RoverTurnRightCommandImpl instance = new RoverTurnRightCommandImpl();
        roverController.processCommand(instance);
        assertNotNull(repository.getCurrentRover());
        assertEquals(1, repository.getCurrentRover().getPositionAndOrientation().getX());
        assertEquals(1, repository.getCurrentRover().getPositionAndOrientation().getY());
        assertEquals(Orientation.East, repository.getCurrentRover().getPositionAndOrientation().getOrientation());
    }

}
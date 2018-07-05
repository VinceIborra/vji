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
public class RoverTurnLeftCommandImplTest {

    public RoverTurnLeftCommandImplTest() {
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
     * Test of equals method, of class RoverTurnLeftCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverTurnLeftCommandImpl command1 = new RoverTurnLeftCommandImpl();
        RoverTurnLeftCommandImpl command2 = new RoverTurnLeftCommandImpl();
        assertEquals(command1, command2);
    }

    /**
     * Test of process method, of class RoverTurnLeftCommandImpl.
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
        RoverTurnLeftCommandImpl instance = new RoverTurnLeftCommandImpl();
        roverController.processCommand(instance);
        assertNotNull(repository.getCurrentRover());
        assertEquals(1, repository.getCurrentRover().getPositionAndOrientation().getX());
        assertEquals(1, repository.getCurrentRover().getPositionAndOrientation().getY());
        assertEquals(Orientation.West, repository.getCurrentRover().getPositionAndOrientation().getOrientation());
    }

}
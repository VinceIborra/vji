package com.tw.marsrover.impl;

import com.tw.marsrover.*;
import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class RoverControllerImplTest {

    public RoverControllerImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setFactory method, of class RoverControllerImpl.
     */
    @Test
    public void testSetFactory() {
        System.out.println("setFactory");
        Factory factory = new FactoryImpl();
        RoverControllerImpl instance = new RoverControllerImpl();
        instance.setFactory(factory);
        assertEquals(factory, instance.getFactory());
    }

    /**
     * Test of getFactory method, of class RoverControllerImpl.
     */
    @Test
    public void testGetFactory() {
        System.out.println("getFactory");
        Factory factory = new FactoryImpl();
        RoverControllerImpl instance = new RoverControllerImpl();
        instance.setFactory(factory);
        assertEquals(factory, instance.getFactory());
    }

    /**
     * Test of setPlateau method, of class RoverControllerImpl.
     */
    @Test
    public void testSetPlateau() {
        System.out.println("setPlateau");
        PlateauImpl plateau = new PlateauImpl();
        RoverControllerImpl instance = new RoverControllerImpl();
        instance.setPlateau(plateau);
        assertEquals(plateau, instance.getPlateau());
    }

    /**
     * Test of getPlateau method, of class RoverControllerImpl.
     */
    @Test
    public void testGetPlateau() {
        System.out.println("getPlateau");
        PlateauImpl plateau = new PlateauImpl();
        RoverControllerImpl instance = new RoverControllerImpl();
        instance.setPlateau(plateau);
        assertEquals(plateau, instance.getPlateau());
    }

    /**
     * Test of processCommand method, of class RoverControllerImpl.
     */
    @Test
    public void testProcessCommand() {
        System.out.println("processCommand");
        FactoryImpl factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        RoverLogger logger = factory.newRoverLogger("test.log");
        RoverControllerImpl instance = new RoverControllerImpl();
        instance.setFactory(factory);
        instance.setPlateau(plateau);
        instance.setRoverRepository(repository);
        instance.setRoverLogger(logger);

        Command command = factory.newPlateauChangeCommand(5, 7);
        instance.processCommand(command);
        assertEquals(5, instance.getPlateau().getX());
        assertEquals(7, instance.getPlateau().getY());

        command = factory.newRoverStartCommand("bob", 1, 2, Orientation.North);
        instance.processCommand(command);
        assertNotNull(instance.getRoverRepository().getCurrentRover());
        assertEquals(1, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getX());
        assertEquals(2, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getY());
        assertEquals(Orientation.North, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getOrientation());

        command = factory.newRoverChangeCommand("bob", RoverChangeEnum.Left);
        instance.processCommand(command);
        assertEquals(Orientation.West, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getOrientation());

        command = factory.newRoverChangeCommand("bob", RoverChangeEnum.Right);
        instance.processCommand(command);
        assertEquals(Orientation.North, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getOrientation());

        command = factory.newRoverChangeCommand("bob", RoverChangeEnum.Move);
        instance.processCommand(command);
        assertEquals(1, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getX());
        assertEquals(3, instance.getRoverRepository().getCurrentRover().getPositionAndOrientation().getY());
    }

}
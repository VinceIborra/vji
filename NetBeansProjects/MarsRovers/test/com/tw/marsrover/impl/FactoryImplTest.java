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
public class FactoryImplTest {

    public FactoryImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of newCommandParser method, of class FactoryImpl.
     */
    @Test
    public void testNewCommandParser() {
        System.out.println("newCommandParser");
        Factory instance = new FactoryImpl();
        CommandParser result = instance.newCommandParser(instance);
        assert(result instanceof CommandParserImpl);
        assertEquals(instance, ((CommandParserImpl) result).getFactory());
    }

    /**
     * Test of newPlateau method, of class FactoryImpl.
     */
    @Test
    public void testNewPlateau() {
        System.out.println("newPlateau");
        FactoryImpl instance = new FactoryImpl();
        Plateau result = instance.newPlateau();
        assert(result instanceof PlateauImpl);
    }

    /**
     * Test of newRoverController method, of class FactoryImpl.
     */
    @Test
    public void testNewRoverController() {
        System.out.println("newRoverController");
        FactoryImpl instance = new FactoryImpl();
        Plateau plateau = instance.newPlateau();
        RoverController result = instance.newRoverController(instance, plateau);
        assert(result instanceof RoverControllerImpl);
        assertEquals(instance, ((RoverControllerImpl) result).getFactory());
        assertEquals(plateau, ((RoverControllerImpl) result).getPlateau());
    }

    /**
     * Test of newPlateauRenderer method, of class FactoryImpl.
     */
    @Test
    public void testNewPlateauRenderer() {
        System.out.println("newPlateauRenderer");
        FactoryImpl instance = new FactoryImpl();
        Plateau plateau = instance.newPlateau();
        PlateauRenderer result = instance.newPlateauRenderer(plateau);
        assert(result instanceof PlateauRendererImpl);
        assertEquals(plateau, ((PlateauRendererImpl) result).getPlateau());
    }

    /**
     * Test of newPlateauChangeCommand method, of class FactoryImpl.
     */
    @Test
    public void testNewPlateauChangeCommand() {
        System.out.println("newPlateauChangeCommand");
        int x = 5;
        int y = 7;
        FactoryImpl instance = new FactoryImpl();
        PlateauChangeCommandImpl expResult = new PlateauChangeCommandImpl();
        expResult.setX(x);
        expResult.setY(y);
        PlateauChangeCommand result = instance.newPlateauChangeCommand(x, y);
        assertEquals(expResult, result);
    }

    /**
     * Test of newRoverStartCommand method, of class FactoryImpl.
     */
    @Test
    public void testNewRoverStartCommand() {
        System.out.println("newRoverStartCommand");
        int x = 2;
        int y = 3;
        Orientation orientation = Orientation.North;
        FactoryImpl instance = new FactoryImpl();
        RoverStartCommandImpl expResult = new RoverStartCommandImpl();
        expResult.setX(x);
        expResult.setY(y);
        expResult.setOrientation(orientation);
        RoverStartCommand result = instance.newRoverStartCommand(x, y, orientation);
        assertEquals(expResult, result);
    }

    /**
     * Test of newRoverChangeCommand method, of class FactoryImpl.
     */
    @Test
    public void testNewRoverChangeCommand() {
        System.out.println("newRoverChangeCommand");
        RoverChangeEnum command = RoverChangeEnum.Move;
        FactoryImpl instance = new FactoryImpl();
        RoverMoveCommandImpl expResult = new RoverMoveCommandImpl();
        RoverChangeCommand result = instance.newRoverChangeCommand(command);
        assertEquals(expResult, result);
    }

    /**
     * Test of newPositionAndOrientation method, of class FactoryImpl.
     */
    @Test
    public void testNewPositionAndOrientation() {
        System.out.println("newPositionAndOrientation");
        int x = 2;
        int y = 3;
        Orientation orientation = Orientation.North;
        FactoryImpl instance = new FactoryImpl();
        PositionAndOrientationImpl expResult = new PositionAndOrientationImpl();
        expResult.setX(x);
        expResult.setY(y);
        expResult.setOrientation(orientation);
        PositionAndOrientation result = instance.newPositionAndOrientation(x, y, orientation);
        assertEquals(expResult, result);
    }

    /**
     * Test of newRover method, of class FactoryImpl.
     */
    @Test
    public void testNewRover() {
        System.out.println("newRover");
        FactoryImpl instance = new FactoryImpl();
        Plateau plateau = instance.newPlateau();
        PositionAndOrientation positionAndOrientation = instance.newPositionAndOrientation(3, 5, Orientation.North);
        Rover result = instance.newRover(instance, plateau, positionAndOrientation);
        assert(result instanceof RoverImpl);
        assertEquals(instance, ((RoverImpl) result).getFactory());
        assertEquals(plateau, ((RoverImpl) result).getPlateau());
    }

    /**
     * Test of newBeacon method, of class FactoryImpl.
     */
    @Test
    public void testNewBeacon() {
        System.out.println("newBeacon");
        FactoryImpl instance = new FactoryImpl();
        Plateau plateau = instance.newPlateau();
        PositionAndOrientation positionAndOrientation = instance.newPositionAndOrientation(3, 5, Orientation.North);
        Beacon result = instance.newBeacon(positionAndOrientation);
        assert(result instanceof BeaconImpl);
        assertEquals(positionAndOrientation, ((BeaconImpl) result).getPositionAndOrientation());
    }

}
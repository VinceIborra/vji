package com.tw.marsrover.impl;

import com.tw.marsrover.*;
import java.util.*;
import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class PlateauImplTest {

    Factory factory = new FactoryImpl();

    public PlateauImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setX method, of class PlateauImpl.
     */
    @Test
    public void testSetX() {
        System.out.println("setX");
        int x = 5;
        PlateauImpl instance = new PlateauImpl();
        instance.setX(x);
        assertEquals(5, instance.getX());
    }

    /**
     * Test of getX method, of class PlateauImpl.
     */
    @Test
    public void testGetX() {
        System.out.println("getX");
        int x = 5;
        PlateauImpl instance = new PlateauImpl();
        instance.setX(x);
        assertEquals(5, instance.getX());
    }

    /**
     * Test of setY method, of class PlateauImpl.
     */
    @Test
    public void testSetY() {
        System.out.println("setY");
        int y = 5;
        PlateauImpl instance = new PlateauImpl();
        instance.setY(y);
        assertEquals(5, instance.getY());
    }

    /**
     * Test of getY method, of class PlateauImpl.
     */
    @Test
    public void testGetY() {
        System.out.println("getY");
        int y = 5;
        PlateauImpl instance = new PlateauImpl();
        instance.setY(y);
        assertEquals(5, instance.getY());
    }

    /**
     * Test of startNewRover method, of class PlateauImpl.
     */
    @Test
    public void testStartNewRover() {
        System.out.println("startNewRover");
        FactoryImpl factory = new FactoryImpl();
        PlateauImpl instance = new PlateauImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover = factory.newRover(factory, instance, positionAndOrientation);
        instance.startNewRover(rover);
        assertEquals(rover, instance.getCurrentRover());
    }

    /**
     * Test of getCurrentRover method, of class PlateauImpl.
     */
    @Test
    public void testGetCurrentRover() {
        System.out.println("getCurrentRover");
        FactoryImpl factory = new FactoryImpl();
        PlateauImpl instance = new PlateauImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover = factory.newRover(factory, instance, positionAndOrientation);
        instance.startNewRover(rover);
        assertEquals(rover, instance.getCurrentRover());
    }

    /**
     * Test of getRovers method, of class PlateauImpl.
     */
    @Test
    public void testGetRovers() {
        System.out.println("getRovers");
        FactoryImpl factory = new FactoryImpl();
        PlateauImpl instance = new PlateauImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover1 = factory.newRover(factory, instance, positionAndOrientation);
        Rover rover2 = factory.newRover(factory, instance, positionAndOrientation);
        instance.startNewRover(rover1);
        instance.startNewRover(rover2);
        ArrayList<Rover> expResult = new ArrayList<Rover>();
        expResult.add(rover1);
        expResult.add(rover2);
        List<Rover> result = instance.getRovers();
        assertEquals(expResult, result);
    }

    /**
     * Test of assertValidPositionAndOrientation method, of class PlateauImpl.
     */
    @Test
    public void testIsPositionInPlateau() {
        System.out.println("isPositionInPlateau");
        FactoryImpl factory = new FactoryImpl();
        Plateau instance = factory.newPlateau();
        instance.setX(5);
        instance.setY(5);
        PositionAndOrientation insidePlateau = factory.newPositionAndOrientation(5, 5, Orientation.North);
        PositionAndOrientation outsidePlateau = factory.newPositionAndOrientation(6, 5, Orientation.North);
        assert(instance.isPositionInPlateau(insidePlateau));
        assert(!instance.isPositionInPlateau(outsidePlateau));
    }

    /**
     * Test of assertValidPositionAndOrientation method, of class PlateauImpl.
     */
    @Test
    public void testAssertValidPositionAndOrientation() {
        System.out.println("assertValidPositionAndOrientation");
        FactoryImpl factory = new FactoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Plateau instance = factory.newPlateau();
        instance.setX(5);
        instance.setY(5);
        instance.assertValidPositionAndOrientation(positionAndOrientation);
    }

    /**
     * Test of place method, of class PlateauImpl.
     */
    @Test
    public void testFindBeaconAt() {
        System.out.println("findBeaconAt");
        Plateau plateau = factory.newPlateau();
        PositionAndOrientation beaconPositionAndOrientation = factory.newPositionAndOrientation(1, 1, Orientation.North);
        Beacon beacon = factory.newBeacon(beaconPositionAndOrientation);
        plateau.place(beacon);
        assertNotNull(plateau.findBeaconAt(1, 1));
        assertNull(plateau.findBeaconAt(2, 2));
    }

    /**
     * Test of place method, of class PlateauImpl.
     */
    @Test
    public void testPlace() {
        System.out.println("place");
        Plateau plateau = factory.newPlateau();
        PositionAndOrientation beaconPositionAndOrientation = factory.newPositionAndOrientation(1, 1, Orientation.North);
        Beacon beacon = factory.newBeacon(beaconPositionAndOrientation);
        plateau.place(beacon);
        assertNotNull(plateau.findBeaconAt(1, 1));
        assertEquals(beacon, plateau.findBeaconAt(1,1));
    }

}
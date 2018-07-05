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
public class PlateauEntityRepositoryImplTest {

    Factory factory = new FactoryImpl();

    public PlateauEntityRepositoryImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of startNewRover method, of class RoverRepositoryImpl.
     */
    @Test
    public void testStartNewRover() {
        System.out.println("startNewRover");
        FactoryImpl factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepositoryImpl instance = new PlateauEntityRepositoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover = factory.newRover(factory, plateau, instance, "bob", positionAndOrientation);
        instance.startNewRover(rover);
        assertEquals(rover, instance.getCurrentRover());
    }

    /**
     * Test of getCurrentRover method, of class RoverRepositoryImpl.
     */
    @Test
    public void testGetCurrentRover() {
        System.out.println("getCurrentRover");
        FactoryImpl factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepositoryImpl instance = new PlateauEntityRepositoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover = factory.newRover(factory, plateau, instance, "bob", positionAndOrientation);
        instance.startNewRover(rover);
        assertEquals(rover, instance.getCurrentRover());
    }

    /**
     * Test of getRovers method, of class RoverRepositoryImpl.
     */
    @Test
    public void testGetRovers() {
        System.out.println("getRovers");
        FactoryImpl factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepositoryImpl instance = new PlateauEntityRepositoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover1 = factory.newRover(factory, plateau, instance, "bob", positionAndOrientation);
        Rover rover2 = factory.newRover(factory, plateau, instance, "jan", positionAndOrientation);
        instance.startNewRover(rover1);
        instance.startNewRover(rover2);
        ArrayList<Rover> expResult = new ArrayList<Rover>();
        expResult.add(rover1);
        expResult.add(rover2);
        List<Rover> result = instance.getRovers();
        assertEquals(expResult, result);
    }

    /**
     * Test of place method, of class RoverRepositoryImpl.
     */
    @Test
    public void testPlace() {
        System.out.println("place");
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        Beacon beacon = factory.newBeacon(4, 5, Orientation.North);
        repository.place(beacon);
        assertNotNull(repository.findBeaconByCoords(4, 5));
        assertEquals(beacon, repository.findBeaconByCoords(4, 5));
    }

    /**
     * Test of findRoverByName method, of class RoverRepositoryImpl.
     */
    @Test
    public void testFindRoverByName() {
        System.out.println("findRoverByName");
        FactoryImpl factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepositoryImpl instance = new PlateauEntityRepositoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(3, 5, Orientation.North);
        Rover rover1 = factory.newRover(factory, plateau, instance, "bob", positionAndOrientation);
        Rover rover2 = factory.newRover(factory, plateau, instance, "jan", positionAndOrientation);
        instance.startNewRover(rover1);
        instance.startNewRover(rover2);
        assertEquals(rover1, instance.findRoverByName("bob"));
    }

    /**
     * Test of findRoverByCoords method, of class RoverRepositoryImpl.
     */
    @Test
    public void testFindRoverByCoords() {
        System.out.println("findRoverByCoords");
        FactoryImpl factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepositoryImpl instance = new PlateauEntityRepositoryImpl();
        PositionAndOrientation positionAndOrientation1 = factory.newPositionAndOrientation(3, 5, Orientation.North);
        PositionAndOrientation positionAndOrientation2 = factory.newPositionAndOrientation(1, 1, Orientation.North);
        Rover rover1 = factory.newRover(factory, plateau, instance, "bob", positionAndOrientation1);
        Rover rover2 = factory.newRover(factory, plateau, instance, "jan", positionAndOrientation2);
        instance.startNewRover(rover1);
        instance.startNewRover(rover2);
        assertEquals(rover1, instance.findRoverByCoords(3,5));
    }

}
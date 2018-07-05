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
public class RoverImplTest {

    Factory factory = new FactoryImpl();

    public RoverImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setFactory method, of class RoverImpl.
     */
    @Test
    public void testSetFactory() {
        System.out.println("setFactory");
        Factory factory = new FactoryImpl();
        RoverImpl instance = new RoverImpl();
        instance.setFactory(factory);
        assertEquals(factory, instance.getFactory());
    }

    /**
     * Test of getFactory method, of class RoverImpl.
     */
    @Test
    public void testGetFactory() {
        System.out.println("getFactory");
        Factory factory = new FactoryImpl();
        RoverImpl instance = new RoverImpl();
        instance.setFactory(factory);
        assertEquals(factory, instance.getFactory());
    }

    /**
     * Test of setPlateau method, of class RoverImpl.
     */
    @Test
    public void testSetPlateau() {
        System.out.println("setPlateau");
        PlateauImpl plateau = new PlateauImpl();
        RoverImpl instance = new RoverImpl();
        instance.setPlateau(plateau);
        assertEquals(plateau, instance.getPlateau());
    }

    /**
     * Test of getPlateau method, of class RoverImpl.
     */
    @Test
    public void testGetPlateau() {
        System.out.println("getPlateau");
        PlateauImpl plateau = new PlateauImpl();
        RoverImpl instance = new RoverImpl();
        instance.setPlateau(plateau);
        assertEquals(plateau, instance.getPlateau());
    }

    /**
     * Test of setRoverRepository method, of class RoverImpl.
     */
    @Test
    public void testSetRoverRepository() {
        System.out.println("setRoverRepository");
        PlateauEntityRepositoryImpl repository = new PlateauEntityRepositoryImpl();
        RoverImpl instance = new RoverImpl();
        instance.setRoverRepository(repository);
        assertEquals(repository, instance.getRoverRepository());
    }

    /**
     * Test of getPlateau method, of class RoverImpl.
     */
    @Test
    public void testGetRoverRepository() {
        System.out.println("getRoverRepository");
        PlateauEntityRepositoryImpl repository = new PlateauEntityRepositoryImpl();
        RoverImpl instance = new RoverImpl();
        instance.setRoverRepository(repository);
        assertEquals(repository, instance.getRoverRepository());
    }

    /**
     * Test of setPositionAndOrientation method, of class RoverImpl.
     */
    @Test
    public void testSetPositionAndOrientation() {
        System.out.println("setPositionAndOrientation");
        PositionAndOrientationImpl positionAndOrientation = new PositionAndOrientationImpl();;
        RoverImpl instance = new RoverImpl();
        instance.setPositionAndOrientation(positionAndOrientation);
        assertEquals(positionAndOrientation, instance.getPositionAndOrientation());
    }

    /**
     * Test of getPositionAndOrientation method, of class RoverImpl.
     */
    @Test
    public void testGetPositionAndOrientation() {
        System.out.println("getPositionAndOrientation");
        PositionAndOrientationImpl positionAndOrientation = new PositionAndOrientationImpl();
        RoverImpl instance = new RoverImpl();
        instance.setPositionAndOrientation(positionAndOrientation);
        assertEquals(positionAndOrientation, instance.getPositionAndOrientation());
    }

    /**
     * Test of setName method, of class RoverImpl.
     */
    @Test
    public void testSetName() {
        System.out.println("setName");
        RoverImpl instance = new RoverImpl();
        instance.setName("bob");
        assertEquals("bob", instance.getName());
    }

    /**
     * Test of getName method, of class RoverImpl.
     */
    @Test
    public void testGetName() {
        System.out.println("getName");
        RoverImpl instance = new RoverImpl();
        instance.setName("bob");
        assertEquals("bob", instance.getName());
    }

    /**
     * Test of turnLeft method, of class RoverImpl.
     */
    @Test
    public void testTurnLeft() {
        System.out.println("turnLeft");
        FactoryImpl factory = new FactoryImpl();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(2, 3, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, repository, "bob", positionAndOrientation);
        instance.turnLeft();
        assertEquals(Orientation.West, instance.getPositionAndOrientation().getOrientation());
    }

    /**
     * Test of turnRight method, of class RoverImpl.
     */
    @Test
    public void testTurnRight() {
        System.out.println("turnRight");
        FactoryImpl factory = new FactoryImpl();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(2, 3, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, repository, "bob", positionAndOrientation);
        instance.turnRight();
        assertEquals(Orientation.East, instance.getPositionAndOrientation().getOrientation());
    }

    /**
     * Test of move method, of class RoverImpl.
     */
    @Test
    public void testMove() {
        System.out.println("move");
        FactoryImpl factory = new FactoryImpl();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(2, 3, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, repository, "bob", positionAndOrientation);
        instance.move();
        assertEquals(2, instance.getPositionAndOrientation().getX());
        assertEquals(4, instance.getPositionAndOrientation().getY());
    }

    @Test(expected=ImminentCollisionException.class)
    public void testMove_WithException() {
        System.out.println("move - with imminent collision exception");
        FactoryImpl factory = new FactoryImpl();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(1, 1, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover rover1 = factory.newRover(factory, plateau, repository, "bob", positionAndOrientation);
        Rover rover2 = factory.newRover(factory, plateau, repository, "jan", positionAndOrientation);
        repository.startNewRover(rover1);
        rover1.move();
        repository.startNewRover(rover2);
        rover2.move();
    }

    @Test(expected=CannotMoveBeaconPresentException.class)
    public void testMove_CannotMoveBeaconPresent() {
        System.out.println("move - can not move beacon present");
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        Plateau plateau = factory.newPlateau(5, 5);
        PositionAndOrientation pao = factory.newPositionAndOrientation(5, 5, Orientation.North);
        Beacon beacon = factory.newBeacon(pao);
        Rover rover = factory.newRover(factory, plateau, repository, null, pao);
        repository.place(beacon);
        repository.startNewRover(rover);
        rover.move();
    }

    /**
     * Test of move method, of class RoverImpl.
     */
    @Test
    public void testMove_ForRoverFallingOverTheEdgeAndLeavingABeacon() {
        System.out.println("move_ForRoverFallingOverTheEdgeAndLeavingABeacon");
        Plateau plateau = factory.newPlateau(5, 5);
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        PositionAndOrientation position = factory.newPositionAndOrientation(5, 5, Orientation.North);
        Rover rover = factory.newRover(factory, plateau, repository, null, position);
        rover.move();
        Beacon beacon = repository.findBeaconByCoords(5, 5);
        assertNotNull(beacon);
        assertEquals(5, beacon.getPositionAndOrientation().getX());
        assertEquals(5, beacon.getPositionAndOrientation().getY());
        assertEquals(Orientation.North, beacon.getPositionAndOrientation().getOrientation());
    }

}
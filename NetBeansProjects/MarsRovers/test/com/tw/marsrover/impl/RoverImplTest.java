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
     * Test of turnLeft method, of class RoverImpl.
     */
    @Test
    public void testTurnLeft() {
        System.out.println("turnLeft");
        FactoryImpl factory = new FactoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(2, 3, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, positionAndOrientation);
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
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(2, 3, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, positionAndOrientation);
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
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(2, 3, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, positionAndOrientation);
        instance.move();
        assertEquals(2, instance.getPositionAndOrientation().getX());
        assertEquals(4, instance.getPositionAndOrientation().getY());
    }

    /**
     * Test of move method, of class RoverImpl.
     */
    @Test
    public void testMove_ForRoverGoingOverTheEdge() {
        System.out.println("move_ForRoverGoingOverTheEdge");
        FactoryImpl factory = new FactoryImpl();
        PositionAndOrientation positionAndOrientation = factory.newPositionAndOrientation(5, 5, Orientation.North);
        Plateau plateau = factory.newPlateau();
        plateau.setX(5);
        plateau.setY(5);
        Rover instance = factory.newRover(factory, plateau, positionAndOrientation);
        instance.move();
        Beacon beacon = plateau.findBeaconAt(5, 5);
        assertNotNull(beacon);
    }

    /**
     * Test of move method, of class RoverImpl.
     */
    @Test
    public void testMove_ForBeaconIndicatingPreviousRoverWentOverTheEdge() {
        System.out.println("move_ForBeaconIndicatingPreviousRoverWentOverTheEdge");
        Plateau plateau = factory.newPlateau(5, 5);
        PositionAndOrientation pao = factory.newPositionAndOrientation(5, 5, Orientation.North);
        Beacon beacon = factory.newBeacon(pao);
        Rover rover = factory.newRover(plateau, pao);
        plateau.place(beacon);
        plateau.place(rover);
        rover.move();
        assertEquals(pao, rover.getPositionAndOrientation());
    }

    /**
     * Test of move isRoverInPlateau, of class RoverImpl.
     */
    @Test
    public void testIsRoverInPlateau() {
        System.out.println("isRoverInPlateau");
        Plateau plateau = factory.newPlateau(5, 5);
        Rover roverInside = factory.newRover(plateau, 5, 5, Orientation.North);
        Rover roverOutside = factory.newRover(plateau, 6, 6, Orientation.North);
        plateau.place(roverInside);
        plateau.place(roverOutside);
        assert(roverInside.isRoverInPlateau());
        assert(!roverOutside.isRoverInPlateau());
    }

}
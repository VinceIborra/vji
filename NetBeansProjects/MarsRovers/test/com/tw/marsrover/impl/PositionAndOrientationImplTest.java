package com.tw.marsrover.impl;

import com.tw.marsrover.Orientation;
import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class PositionAndOrientationImplTest {

    public PositionAndOrientationImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setX method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testSetX() {
        System.out.println("setX");
        int x = 3;
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setX(x);
        assertEquals(3, instance.getX());
    }

    /**
     * Test of getX method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testGetX() {
        System.out.println("getX");
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setX(3);
        int expResult = 3;
        int result = instance.getX();
        assertEquals(expResult, result);
    }

    /**
     * Test of setY method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testSetY() {
        System.out.println("setY");
        int y = 5;
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setY(y);
        assertEquals(5, instance.getY());
    }

    /**
     * Test of getY method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testGetY() {
        System.out.println("getY");
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setY(5);
        int expResult = 5;
        int result = instance.getY();
        assertEquals(expResult, result);
    }

    /**
     * Test of setOrientation method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testSetOrientation() {
        System.out.println("setOrientation");
        Orientation orientation = Orientation.North;
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setOrientation(orientation);
        assertEquals(Orientation.North, instance.getOrientation());
    }

    /**
     * Test of getOrientation method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testGetOrientation() {
        System.out.println("getOrientation");
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setOrientation(Orientation.North);
        Orientation expResult = Orientation.North;
        Orientation result = instance.getOrientation();
        assertEquals(expResult, result);
    }

    /**
     * Test of equals method, of class PositionAndOrientationImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        Object obj = null;
        PositionAndOrientationImpl instance = new PositionAndOrientationImpl();
        instance.setX(3);
        instance.setY(5);
        instance.setOrientation(Orientation.North);
        PositionAndOrientationImpl expResult = new PositionAndOrientationImpl();
        expResult.setX(3);
        expResult.setY(5);
        expResult.setOrientation(Orientation.North);
        assertEquals(expResult, instance);
    }
}
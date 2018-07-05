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
public class RoverStartCommandImplTest {

    public RoverStartCommandImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setX method, of class RoverStartCommandImpl.
     */
    @Test
    public void testSetX() {
        System.out.println("setX");
        int x = 2;
        RoverStartCommandImpl instance = new RoverStartCommandImpl();
        instance.setX(x);
        assertEquals(2, instance.getX());
    }

    /**
     * Test of getX method, of class RoverStartCommandImpl.
     */
    @Test
    public void testGetX() {
        System.out.println("getX");
        int x = 2;
        RoverStartCommandImpl instance = new RoverStartCommandImpl();
        instance.setX(x);
        assertEquals(2, instance.getX());
    }

    /**
     * Test of setY method, of class RoverStartCommandImpl.
     */
    @Test
    public void testSetY() {
        System.out.println("setY");
        int y = 3;
        RoverStartCommandImpl instance = new RoverStartCommandImpl();
        instance.setY(y);
        assertEquals(3, instance.getY());
    }

    /**
     * Test of getY method, of class RoverStartCommandImpl.
     */
    @Test
    public void testGetY() {
        System.out.println("getY");
        int y = 3;
        RoverStartCommandImpl instance = new RoverStartCommandImpl();
        instance.setY(y);
        assertEquals(3, instance.getY());
    }

    /**
     * Test of setOrientation method, of class RoverStartCommandImpl.
     */
    @Test
    public void testSetOrientation() {
        System.out.println("setOrientation");
        Orientation orientation = Orientation.North;
        RoverStartCommandImpl instance = new RoverStartCommandImpl();
        instance.setOrientation(orientation);
        assertEquals(Orientation.North, instance.getOrientation());
    }

    /**
     * Test of getOrientation method, of class RoverStartCommandImpl.
     */
    @Test
    public void testGetOrientation() {
        System.out.println("getOrientation");
        Orientation orientation = Orientation.North;
        RoverStartCommandImpl instance = new RoverStartCommandImpl();
        instance.setOrientation(orientation);
        assertEquals(Orientation.North, instance.getOrientation());
    }

    /**
     * Test of equals method, of class RoverStartCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverStartCommandImpl command1 = new RoverStartCommandImpl();
        RoverStartCommandImpl command2 = new RoverStartCommandImpl();
        assertEquals(command1, command2);
    }

}
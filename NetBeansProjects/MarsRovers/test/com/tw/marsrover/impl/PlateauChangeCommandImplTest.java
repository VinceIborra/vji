package com.tw.marsrover.impl;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class PlateauChangeCommandImplTest {

    public PlateauChangeCommandImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setX method, of class PlateauChangeCommandImpl.
     */
    @Test
    public void testSetX() {
        System.out.println("setX");
        int x = 3;
        PlateauChangeCommandImpl instance = new PlateauChangeCommandImpl();
        instance.setX(x);
        assertEquals(3, instance.getX());
    }

    /**
     * Test of getX method, of class PlateauChangeCommandImpl.
     */
    @Test
    public void testGetX() {
        System.out.println("getX");
        int x = 3;
        PlateauChangeCommandImpl instance = new PlateauChangeCommandImpl();
        instance.setX(x);
        assertEquals(3, instance.getX());
    }

    /**
     * Test of setY method, of class PlateauChangeCommandImpl.
     */
    @Test
    public void testSetY() {
        System.out.println("setY");
        int y = 5;
        PlateauChangeCommandImpl instance = new PlateauChangeCommandImpl();
        instance.setY(y);
        assertEquals(5, instance.getY());
    }

    /**
     * Test of getY method, of class PlateauChangeCommandImpl.
     */
    @Test
    public void testGetY() {
        System.out.println("getY");
        int y = 5;
        PlateauChangeCommandImpl instance = new PlateauChangeCommandImpl();
        instance.setY(y);
        assertEquals(5, instance.getY());
    }

    /**
     * Test of equals method, of class PlateauChangeCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        Object obj = null;
        PlateauChangeCommandImpl instance = new PlateauChangeCommandImpl();
        instance.setX(3);
        instance.setY(5);
        PlateauChangeCommandImpl expResult = new PlateauChangeCommandImpl();
        expResult.setX(3);
        expResult.setY(5);
        assertEquals(expResult, instance);
    }

}
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
     * Test of assertValidPositionAndOrientation method, of class PlateauImpl.
     */
    @Test
    public void testIsPositionInPlateau() {
        System.out.println("isPositionInPlateau");
        FactoryImpl factory = new FactoryImpl();
        Plateau instance = factory.newPlateau();
        instance.setX(5);
        instance.setY(5);
        assert(instance.isPositionInPlateau(1, 1));
        assert(!instance.isPositionInPlateau(6, 6));
    }

}
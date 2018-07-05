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
public class BeaconTest {

    Factory factory = new FactoryImpl();

    public BeaconTest() {
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
    public void test_FactoryCreation() {
        System.out.println("test_FactoryCreation");
        Beacon beacon = factory.newBeacon(4, 5, Orientation.North);
        assertNotNull(beacon);
        assertEquals(4, beacon.getPositionAndOrientation().getX());
        assertEquals(5, beacon.getPositionAndOrientation().getY());
    }

}
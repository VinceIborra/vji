package com.tw.marsrover.impl;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class RoverTurnLeftCommandImplTest {

    public RoverTurnLeftCommandImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Test
    public void testSomeMethod() {
        // Nothing to do
        assert(true);
    }

    /**
     * Test of equals method, of class RoverTurnLeftCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverTurnLeftCommandImpl command1 = new RoverTurnLeftCommandImpl();
        RoverTurnLeftCommandImpl command2 = new RoverTurnLeftCommandImpl();
        assertEquals(command1, command2);
    }

}
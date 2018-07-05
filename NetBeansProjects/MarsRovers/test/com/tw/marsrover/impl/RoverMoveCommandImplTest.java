package com.tw.marsrover.impl;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class RoverMoveCommandImplTest {

    public RoverMoveCommandImplTest() {
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
     * Test of equals method, of class RoverMoveCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverMoveCommandImpl command1 = new RoverMoveCommandImpl();
        RoverMoveCommandImpl command2 = new RoverMoveCommandImpl();
        assertEquals(command1, command2);
    }

}
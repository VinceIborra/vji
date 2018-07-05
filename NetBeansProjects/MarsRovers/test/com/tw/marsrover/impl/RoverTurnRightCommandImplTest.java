package com.tw.marsrover.impl;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class RoverTurnRightCommandImplTest {

    public RoverTurnRightCommandImplTest() {
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
     * Test of equals method, of class RoverTurnRightCommandImpl.
     */
    @Test
    public void testEquals() {
        System.out.println("equals");
        RoverTurnRightCommandImpl command1 = new RoverTurnRightCommandImpl();
        RoverTurnRightCommandImpl command2 = new RoverTurnRightCommandImpl();
        assertEquals(command1, command2);
    }

}
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
public class AnonymousRoverCommandParserImplTest {

    public AnonymousRoverCommandParserImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setFactory method, of class CommandParserImpl.
     */
    @Test
    public void testSetFactory() {
        System.out.println("setFactory");
        Factory factory = new FactoryImpl();
        AnonymousRoverCommandParserImpl instance = new AnonymousRoverCommandParserImpl();
        instance.setFactory(factory);
        assertEquals(factory, instance.getFactory());
    }

    /**
     * Test of getFactory method, of class CommandParserImpl.
     */
    @Test
    public void testGetFactory() {
        System.out.println("getFactory");
        Factory factory = new FactoryImpl();
        AnonymousRoverCommandParserImpl instance = new AnonymousRoverCommandParserImpl();
        instance.setFactory(factory);
        assertEquals(factory, instance.getFactory());
    }

    /**
     * Test of parseTextLine method, of class CommandParserImpl.
     */
    @Test
    public void testParseTextLine() {
        System.out.println("parseTextLine");
        Factory factory = new FactoryImpl();
        CommandParser instance = factory.newAnonymousRoverCommandParser(factory);
        

        String line = "5 5";
        List<Command> expResult = new ArrayList<Command>();
        expResult.add(factory.newPlateauChangeCommand(5, 5));
        List<Command> result = instance.parseTextLine(line);
        assertEquals(expResult, result);
    }


}

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
public class NamedRoverCommandParserImplTest {

    public NamedRoverCommandParserImplTest() {
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
        NamedRoverCommandParserImpl instance = new NamedRoverCommandParserImpl();
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
        NamedRoverCommandParserImpl instance = new NamedRoverCommandParserImpl();
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
        CommandParser instance = factory.newNamedRoverCommandParser(factory);
        

        String line = "5 5";
        List<Command> expResult = new ArrayList<Command>();
        expResult.add(factory.newPlateauChangeCommand(5, 5));
        List<Command> result = instance.parseTextLine(line);
        assertEquals(expResult, result);
    }

    /**
     * Test of parseTextLine method, of class CommandParserImpl.
     */
    @Test
    public void testParseTextLine_ForRoverStartCommand() {
        System.out.println("parseTextLine_ForRoverStartCommand");
        Factory factory = new FactoryImpl();
        CommandParser instance = factory.newNamedRoverCommandParser(factory);


        String line = "bob 1 1 N";
        List<Command> expResult = new ArrayList<Command>();
        expResult.add(factory.newRoverStartCommand("bob", 1, 1, Orientation.North));
        List<Command> result = instance.parseTextLine(line);
        assertEquals(expResult, result);
    }

}

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
public class PlateauAndRoversRendererImplTest {

    public PlateauAndRoversRendererImplTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    /**
     * Test of setPlateau method, of class PlateauRendererImpl.
     */
    @Test
    public void testSetPlateau() {
        System.out.println("setPlateau");
        PlateauImpl plateau = new PlateauImpl();
        PlateauAndRoversRendererImpl instance = new PlateauAndRoversRendererImpl();
        instance.setPlateau(plateau);
        assertEquals(plateau, instance.getPlateau());
    }

    /**
     * Test of getPlateau method, of class PlateauRendererImpl.
     */
    @Test
    public void testGetPlateau() {
        System.out.println("getPlateau");
        PlateauImpl plateau = new PlateauImpl();
        PlateauAndRoversRendererImpl instance = new PlateauAndRoversRendererImpl();
        instance.setPlateau(plateau);
        assertEquals(plateau, instance.getPlateau());
    }

    /**
     * Test of render method, of class PlateauRendererImpl.
     */
    @Test
    public void testRender() {
        System.out.println("render");
        PlateauAndRoversRendererImpl instance = new PlateauAndRoversRendererImpl();
        Factory factory = new FactoryImpl();
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        PositionAndOrientationImpl positionAndOrientation = new PositionAndOrientationImpl();
        positionAndOrientation.setX(3);
        positionAndOrientation.setY(7);
        positionAndOrientation.setOrientation(Orientation.North);
        RoverImpl rover = new RoverImpl();
        rover.setPlateau(plateau);
        rover.setPositionAndOrientation(positionAndOrientation);
        repository.startNewRover(rover);
        instance.setPlateau(plateau);
        instance.setRoverRepository(repository);

        instance.render();
    }

}
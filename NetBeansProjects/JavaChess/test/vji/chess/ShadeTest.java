package vji.chess;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class ShadeTest {

    @Test
    public void testValues() {
        System.out.println("values");
        Shade[] expected = new Shade[]{
            Shade.Light,
            Shade.Dark
        };
        assertArrayEquals(expected, Shade.values);
    }

}
package vji.chess;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class KnightImplTest {

    @Test
    public void testImpl() {
        KnightImpl knightImpl = new KnightImpl();
        knightImpl.setColour(Colour.Black);
        Knight knight = knightImpl;
        assertEquals(Colour.Black, knight.getColour());
    }

}
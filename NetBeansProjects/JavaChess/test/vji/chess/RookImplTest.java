package vji.chess;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class RookImplTest {

    @Test
    public void testImpl() {
        RookImpl rookImpl = new RookImpl();
        rookImpl.setColour(Colour.Black);
        Rook rook = rookImpl;
        assertEquals(Colour.Black, rook.getColour());
    }

}
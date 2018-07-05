package vji.chess;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class PawnImplTest {

    @Test
    public void testImpl() {
        PawnImpl pawnImpl = new PawnImpl();
        pawnImpl.setColour(Colour.Black);
        Pawn pawn = pawnImpl;
        assertEquals(Colour.Black, pawn.getColour());
    }

}
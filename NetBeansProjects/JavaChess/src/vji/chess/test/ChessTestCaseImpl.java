package vji.chess.test;
import java.util.*;
import static org.junit.Assert.*;
import vji.chess.*;

/**
 *
 * @author vji
 */
public class ChessTestCaseImpl {
    protected void assertPieceEquals(Class klass, Colour colour, Piece piece) {
        assertNotNull(piece);
        assertTrue(Arrays.asList(piece.getClass().getInterfaces()).contains(klass));
        assertEquals(colour, piece.getColour());
    }
}

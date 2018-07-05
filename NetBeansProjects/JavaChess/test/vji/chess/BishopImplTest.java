package vji.chess;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class BishopImplTest {

    @Test
    public void testImpl() {
        BishopImpl bishopImpl = new BishopImpl();
        assertTrue(bishopImpl instanceof PieceImpl);
        assertTrue(bishopImpl instanceof Bishop);
    }
}
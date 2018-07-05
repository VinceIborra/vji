package vji.chess;

import org.junit.Test;
import org.junit.Before;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class FactoryImplTest {

    private ChessFactory _factory;

    private void setFactory(ChessFactory factory) { _factory = factory; }
    private ChessFactory getFactory() { return _factory; }

    @Before
    public void setUp() {
        setFactory(new ChessFactoryImpl());
    }

    @Test
    public void testNewSquare() {
        File file = File.FileA;
        Rank rank = Rank.Rank1;
        Shade shade = Shade.Dark;
        Square square = getFactory().newSquare(file, rank, shade);
        assertNotNull(square);
        assertEquals(file, square.getFile());
        assertEquals(rank, square.getRank());
        assertEquals(shade, square.getShade());
    }

    @Test
    public void testNewPawn() {
        Pawn pawn = getFactory().newPawn(Colour.Black);
        assertNotNull(pawn);
        assertTrue(pawn instanceof PawnImpl);
        assertEquals(Colour.Black, pawn.getColour());
    }

    @Test
    public void testNewRook() {
        Rook rook = getFactory().newRook(Colour.Black);
        assertNotNull(rook);
        assertTrue(rook instanceof RookImpl);
        assertEquals(Colour.Black, rook.getColour());
    }

    @Test
    public void testNewKnight() {
        Knight knight = getFactory().newKnight(Colour.Black);
        assertNotNull(knight);
        assertTrue(knight instanceof KnightImpl);
        assertEquals(Colour.Black, knight.getColour());
    }

    @Test
    public void testNewBishop() {
        Bishop bishop = getFactory().newBishop(Colour.Black);
        assertNotNull(bishop);
        assertTrue(bishop instanceof BishopImpl);
        assertEquals(Colour.Black, bishop.getColour());
    }

    @Test
    public void testNewQueen() {
        Queen queen = getFactory().newQueen(Colour.Black);
        assertNotNull(queen);
        assertTrue(queen instanceof QueenImpl);
        assertEquals(Colour.Black, queen.getColour());
    }

    @Test
    public void testNewKing() {
        King king = getFactory().newKing(Colour.Black);
        assertNotNull(king);
        assertTrue(king instanceof KingImpl);
        assertEquals(Colour.Black, king.getColour());
    }

}

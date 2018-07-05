package vji.chess;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class ChessFactoryImplTest {

    private ChessFactory _chessFactory;

    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private ChessFactory getChessFactory() { return _chessFactory; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
    }

    @Test
    public void testNewBoard() {
        Board board = getChessFactory().newBoard();
        assertNotNull(board);
        assertTrue(board instanceof BoardImpl);
        BoardImpl boardImpl = (BoardImpl) board;
        assertEquals(getChessFactory(), boardImpl.getChessFactory());
    }

    @Test
    public void testNewMove() {
        Class pieceType = Pawn.class;
        File fromFile = File.FileA;
        Rank fromRank = Rank.Rank1;
        File toFile = File.FileB;
        Rank toRank = Rank.Rank2;
        boolean capture = false;
        Move move = getChessFactory().newMove(pieceType, fromFile, fromRank, toFile, toRank, capture);
        assertNotNull(move);
        assertTrue(move instanceof MoveImpl);
        assertEquals(pieceType, move.getPieceType());
        assertEquals(fromFile, move.getFromFile());
        assertEquals(fromRank, move.getFromRank());
        assertEquals(toFile, move.getToFile());
        assertEquals(toRank, move.getToRank());
        assertEquals(capture, move.getCapture());
    }
}
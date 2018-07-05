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
public class SquareImplTest {

    private ChessFactory _factory;

    private void setFactory(ChessFactory factory) { _factory = factory; }
    private ChessFactory getFactory() { return _factory; }

    @Before
    public void setUp() {
        setFactory(new ChessFactoryImpl());
    }

    @Test
    public void testImpl() {
        System.out.println("Impl");
        File file = File.FileA;
        Rank rank = Rank.Rank1;
        Shade shade = Shade.Dark;
        SquareImpl square = new SquareImpl();
        square.setFile(file);
        square.setRank(rank);
        square.setShade(shade);
        assertEquals(file, square.getFile());
        assertEquals(rank, square.getRank());
        assertEquals(shade, square.getShade());
    }
}
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
public class RankTest {

    @Test
    public void testToIdx() {
        int idx = 0;
        for (Rank rank : Rank.values) {
            assertEquals(idx, rank.getIdx());
            idx++;
        }
    }

    @Test
    public void testValues() {
        System.out.println("values");
        Rank[] expected = new Rank[]{
            Rank.Rank1,
            Rank.Rank2,
            Rank.Rank3,
            Rank.Rank4,
            Rank.Rank5,
            Rank.Rank6,
            Rank.Rank7,
            Rank.Rank8
        };
        assertArrayEquals(expected, Rank.values);
    }

    @Test
    public void testFromString() {
        assertEquals(Rank.Rank1, Rank.fromString("1"));
        assertEquals(Rank.Rank2, Rank.fromString("2"));
        assertEquals(Rank.Rank3, Rank.fromString("3"));
        assertEquals(Rank.Rank4, Rank.fromString("4"));
        assertEquals(Rank.Rank5, Rank.fromString("5"));
        assertEquals(Rank.Rank6, Rank.fromString("6"));
        assertEquals(Rank.Rank7, Rank.fromString("7"));
        assertEquals(Rank.Rank8, Rank.fromString("8"));
    }

}
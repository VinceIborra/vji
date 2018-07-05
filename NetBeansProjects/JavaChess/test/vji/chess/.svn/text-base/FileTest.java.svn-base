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
public class FileTest {

    @Test
    public void testToIdx() {
        int idx = 0;
        for (File file : File.values) {
            assertEquals(idx, file.getIdx());
            idx++;
        }
    }

    @Test
    public void testValues() {
        System.out.println("values");
        File[] expected = new File[]{
            File.FileA,
            File.FileB,
            File.FileC,
            File.FileD,
            File.FileE,
            File.FileF,
            File.FileG,
            File.FileH
        };
        assertArrayEquals(expected, File.values);
    }

    @Test
    public void testFromString() {
        assertEquals(File.FileA, File.fromString("a"));
        assertEquals(File.FileB, File.fromString("b"));
        assertEquals(File.FileC, File.fromString("c"));
        assertEquals(File.FileD, File.fromString("d"));
        assertEquals(File.FileE, File.fromString("e"));
        assertEquals(File.FileF, File.fromString("f"));
        assertEquals(File.FileG, File.fromString("g"));
        assertEquals(File.FileH, File.fromString("h"));
    }
}
package vji.chess;
import java.util.*;

/**
 *
 * @author vji
 */
public class File {

    private String _value;
    private int _idx;

    public String getValue() { return _value; }
    public int getIdx() { return _idx; }

    private File(String value, int idx) {
        _value = value;
        _idx = idx;
    }
    
    public static File FileA = new File("A", 0);
    public static File FileB = new File("B", 1);
    public static File FileC = new File("C", 2);
    public static File FileD = new File("D", 3);
    public static File FileE = new File("E", 4);
    public static File FileF = new File("F", 5);
    public static File FileG = new File("G", 6);
    public static File FileH = new File("H", 7);

    public static File[] values = new File[] {
        File.FileA,
        File.FileB,
        File.FileC,
        File.FileD,
        File.FileE,
        File.FileF,
        File.FileG,
        File.FileH
    };

    public static File fromString(String str) {
        String capitalisedStr = str.toUpperCase();
        for (File file : Arrays.asList(File.values)) {
            if (file.getValue().equals(capitalisedStr)) {
                return file;
            }
        }
        return null;
    }
}

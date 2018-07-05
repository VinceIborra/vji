package vji.chess;

/**
 *
 * @author vji
 */
public class Rank {

    private String _value;
    private int _idx;

    public String getValue() { return _value; }
    public int getIdx() { return _idx; }

    private Rank(String value, int idx) {
        _value = value;
        _idx = idx;
    }

    public static Rank Rank1 = new Rank("1", 0);
    public static Rank Rank2 = new Rank("2", 1);
    public static Rank Rank3 = new Rank("3", 2);
    public static Rank Rank4 = new Rank("4", 3);
    public static Rank Rank5 = new Rank("5", 4);
    public static Rank Rank6 = new Rank("6", 5);
    public static Rank Rank7 = new Rank("7", 6);
    public static Rank Rank8 = new Rank("8", 7);

    public static Rank[] values = new Rank[] {
        Rank.Rank1,
        Rank.Rank2,
        Rank.Rank3,
        Rank.Rank4,
        Rank.Rank5,
        Rank.Rank6,
        Rank.Rank7,
        Rank.Rank8
    };

    public static Rank fromString(String str) {
        String capitalisedStr = str.toUpperCase();
        for (int idx=0; idx < Rank.values.length; idx++) {
            Rank rank = Rank.values[idx];
            if (rank.getValue().equals(capitalisedStr)) {
                return rank;
            }
        }
        return null;
    }

}

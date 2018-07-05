package com.tw.marsrover;

/**
 *
 * @author vji
 */
public enum Orientation {
    North { public String toString() { return "N";} },
    South { public String toString() { return "S";} },
    East  { public String toString() { return "E";} },
    West  { public String toString() { return "W";} };

    public static Orientation fromString(String string) {
        if (string.toLowerCase().equals("n")) {
            return Orientation.North;
        }
        else if (string.toLowerCase().equals("s")) {
            return Orientation.South;
        }
        else if (string.toLowerCase().equals("e")) {
            return Orientation.East;
        }
        else if (string.toLowerCase().equals("w")) {
            return Orientation.West;
        }

        return null;
    }
}

package com.tw.marsrover;

/**
 *
 * @author vji
 */
public enum RoverChangeEnum {
    Left, Right, Move;

    public static RoverChangeEnum fromString(String string) {
        if (string.toLowerCase().equals("l")) {
            return RoverChangeEnum.Left;
        }
        else if (string.toLowerCase().equals("r")) {
            return RoverChangeEnum.Right;
        }
        else if (string.toLowerCase().equals("m")) {
            return RoverChangeEnum.Move;
        }

        return null;
    }
}

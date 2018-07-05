package vji.chess;

/**
 *
 * @author vji
 */
public interface Move {
    Class getPieceType();
    Rank getFromRank();
    File getFromFile();
    Rank getToRank();
    File getToFile();
    boolean getCapture();
}

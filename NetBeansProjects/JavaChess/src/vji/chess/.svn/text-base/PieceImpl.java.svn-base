package vji.chess;


/**
 *
 * @author vji
 */
public abstract class PieceImpl implements Piece {

    private Colour _colour;

    public void setColour(Colour colour) { _colour = colour; }
    public Colour getColour() { return _colour; }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (!getClass().equals(obj.getClass())) {
            return false;
        }
        Piece piece = (Piece) obj;
        if (!getColour().equals(piece.getColour())) {
            return false;
        }
        return true;
    }

}

package vji.chess;

/**
 *
 * @author vji
 */
public class MoveImpl implements Move {

    private Class _pieceType;
    private Rank _fromRank;
    private File _fromFile;
    private Rank _toRank;
    private File _toFile;
    private boolean _capture;

    public void setPieceType(Class pieceType) { _pieceType = pieceType; }
    public void setFromRank(Rank fromRank) { _fromRank = fromRank; }
    public void setFromFile(File fromFile) { _fromFile = fromFile; }
    public void setToRank(Rank toRank) { _toRank = toRank; }
    public void setToFile(File toFile) { _toFile = toFile; }
    public void setCapture(boolean capture) { _capture = capture; }

    @Override
    public Class getPieceType() { return _pieceType; }

    @Override
    public Rank getFromRank() { return _fromRank; }

    @Override
    public File getFromFile() { return _fromFile; }

    @Override
    public Rank getToRank() { return _toRank; }

    @Override
    public File getToFile() { return _toFile; }
    
    @Override
    public boolean getCapture() { return _capture; }
}

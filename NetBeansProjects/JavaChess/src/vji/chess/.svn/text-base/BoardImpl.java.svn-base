package vji.chess;

import com.sun.org.apache.xerces.internal.impl.xs.identity.ValueStore;

/**
 *
 * @author vji
 */
public class BoardImpl implements Board {

    private ChessFactory _factory;
    private Square[][] _squares;

    public void setChessFactory(ChessFactory factory) { _factory = factory; }
    private void setSquares(Square[][] squares) { _squares = squares; }

    public ChessFactory getChessFactory() { return _factory; }
    private Square[][] getSquares() { return _squares; }

    private void createSquares() {
        _squares = new Square[File.values.length][Rank.values.length];
        Shade firstShade = Shade.Dark;
        Shade shade;
        for (File file : File.values) {
            shade = firstShade;
            for (Rank rank : Rank.values) {
                Square square = getChessFactory().newSquare(file, rank, shade);
                _squares[file.getIdx()][rank.getIdx()] = square;
                shade = (shade == Shade.Light)? Shade.Dark : Shade.Light;
            }
            firstShade = (shade == Shade.Light)? Shade.Dark : Shade.Light;
        }
    }

    private void ensureSquaresHaveBeenCreated() {
        if (getSquares() == null) {
            createSquares();
        }
    }

    public Square getSquareAt(File file, Rank rank) {
        ensureSquaresHaveBeenCreated();
        return getSquares()[file.getIdx()][rank.getIdx()];
    }

    public void setPieceAt(Piece piece, File file, Rank rank) {
        getSquareAt(file, rank).setPiece(piece);
    }
    public Piece getPieceAt(File file, Rank rank) {
        return getSquareAt(file, rank).getPiece();
    }

    public void clearPieces() {
        for (File file : File.values) {
            for (Rank rank : Rank.values) {
                getSquareAt(file, rank).setPiece(null);
            }
        }
    }
    
    public void arrangePieces() {

        // Clear the board first
        clearPieces();

        // Place non-pawn black pieces
        Rank rank = Rank.Rank8;
        Colour colour = Colour.Black;
        setPieceAt(getChessFactory().newRook(colour),   File.FileA, rank);
        setPieceAt(getChessFactory().newKnight(colour), File.FileB, rank);
        setPieceAt(getChessFactory().newBishop(colour), File.FileC, rank);
        setPieceAt(getChessFactory().newQueen(colour),  File.FileD, rank);
        setPieceAt(getChessFactory().newKing(colour),   File.FileE, rank);
        setPieceAt(getChessFactory().newBishop(colour), File.FileF, rank);
        setPieceAt(getChessFactory().newKnight(colour), File.FileG, rank);
        setPieceAt(getChessFactory().newRook(colour),   File.FileH, rank);

        // Place black pawns
        rank = Rank.Rank7;
        for (File file: File.values) {
            setPieceAt(getChessFactory().newPawn(colour), file, rank);
        }

        // Place white pawns
        rank = Rank.Rank2;
        colour = Colour.White;
        for (File file : File.values) {
            setPieceAt(getChessFactory().newPawn(colour), file, rank);
        }

        rank = Rank.Rank1;
        setPieceAt(getChessFactory().newRook(colour),   File.FileA, rank);
        setPieceAt(getChessFactory().newKnight(colour), File.FileB, rank);
        setPieceAt(getChessFactory().newBishop(colour), File.FileC, rank);
        setPieceAt(getChessFactory().newQueen(colour),  File.FileD, rank);
        setPieceAt(getChessFactory().newKing(colour),   File.FileE, rank);
        setPieceAt(getChessFactory().newBishop(colour), File.FileF, rank);
        setPieceAt(getChessFactory().newKnight(colour), File.FileG, rank);
        setPieceAt(getChessFactory().newRook(colour),   File.FileH, rank);
    }

    @Override
    public void movePiece(Move move) {
        Square fromSquare = getSquareAt(move.getFromFile(), move.getFromRank());
        Square toSquare = getSquareAt(move.getToFile(), move.getToRank());
        Piece piece = fromSquare.getPiece();
        fromSquare.setPiece(null);
        toSquare.setPiece(piece);
    }
}

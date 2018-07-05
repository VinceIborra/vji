package vji.chess;

/**
 *
 * @author vji
 */
public class ChessFactoryImpl implements ChessFactory {

    public Pawn newPawn(Colour colour) {
        PawnImpl pawn = new PawnImpl();
        pawn.setColour(colour);
        return pawn;
    }

    public Rook newRook(Colour colour) {
        RookImpl rook = new RookImpl();
        rook.setColour(colour);
        return rook;
    }

    public Knight newKnight(Colour colour) {
        KnightImpl knight = new KnightImpl();
        knight.setColour(colour);
        return knight;
    }

    public Bishop newBishop(Colour colour) {
        BishopImpl bishop = new BishopImpl();
        bishop.setColour(colour);
        return bishop;
    }

    public Queen newQueen(Colour colour) {
        QueenImpl queen = new QueenImpl();
        queen.setColour(colour);
        return queen;
    }

    public King newKing(Colour colour) {
        KingImpl king = new KingImpl();
        king.setColour(colour);
        return king;
    }

    public Square newSquare(File file, Rank rank, Shade shade) {
        SquareImpl square = new SquareImpl();
        square.setFile(file);
        square.setRank(rank);
        square.setShade(shade);
        return square;
    }

    @Override
    public Board newBoard() {
        BoardImpl board = new BoardImpl();
        board.setChessFactory(this);
        return board;
    }

    @Override
    public Move newMove(Class pieceType, File fromFile, Rank fromRank, File toFile, Rank toRank, boolean capture) {
        MoveImpl move = new MoveImpl();
        move.setPieceType(pieceType);
        move.setFromFile(fromFile);
        move.setFromRank(fromRank);
        move.setToFile(toFile);
        move.setToRank(toRank);
        move.setCapture(capture);
        return move;
    }
}

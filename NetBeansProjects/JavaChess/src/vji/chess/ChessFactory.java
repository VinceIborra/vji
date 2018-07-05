package vji.chess;

/**
 *
 * @author vji
 */
public interface ChessFactory {

    Pawn newPawn(Colour colour);
    Rook newRook(Colour colour);
    Knight newKnight(Colour colour);
    Bishop newBishop(Colour colour);
    Queen newQueen(Colour colour);
    King newKing(Colour colour);

    Square newSquare(File file, Rank rank, Shade shade);

    Board newBoard();

    Move newMove(Class pieceType, File fromFile, Rank fromRank, File toFile, Rank toRank, boolean capture);
}

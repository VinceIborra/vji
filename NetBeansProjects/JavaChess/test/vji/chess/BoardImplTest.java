package vji.chess;

import org.junit.Test;
import org.junit.Before;
import static org.junit.Assert.*;

/**
 *
 * @author vji
 */
public class BoardImplTest {

    private ChessFactory _chessFactory;
    private Board _board;
    private Board _arrangedBoard;
    private BoardImpl _boardImpl;

    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private void setBoard(Board board) { _board = board; }
    private void setBoardImpl(BoardImpl boardImpl) { _boardImpl = boardImpl; }
    private void setArrangedBoard(Board board) { _arrangedBoard = board; }

    private ChessFactory getChessFactory() { return _chessFactory; }
    private Board getBoard() { return _board; }
    private BoardImpl getBoardImpl() { return _boardImpl; }
    private Board getArrangedBoard() { return _arrangedBoard; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
        setBoard(getChessFactory().newBoard());
        setBoardImpl((BoardImpl) getBoard());
        setArrangedBoard(getChessFactory().newBoard());
        getArrangedBoard().arrangePieces();
    }

    @Test
    public void testSquareAt() {
        Board board = getBoard();
        for (File file : File.values) {
            for (Rank rank : Rank.values) {
                Square square = board.getSquareAt(file, rank);
                assertNotNull(square);
                assertEquals(file, square.getFile());
                assertEquals(rank, square.getRank());
            }
        }
    }

    @Test
    public void testSetPiece() {
        BoardImpl board = getBoardImpl();
        File file = File.FileA;
        Rank rank = Rank.Rank8;
        assertNull(board.getPieceAt(file, rank));
        Bishop bishop = getChessFactory().newBishop(Colour.Black);
        board.setPieceAt(bishop, file, rank);
        assertEquals(bishop, board.getPieceAt(file, rank));
    }

    @Test
    public void testClearPieces() {
        BoardImpl board = getBoardImpl();
        File file = File.FileA;
        Rank rank = Rank.Rank8;
        assertNull(board.getPieceAt(file, rank));
        Bishop bishop = getChessFactory().newBishop(Colour.Black);
        board.setPieceAt(bishop, file, rank);
        assertEquals(bishop, board.getPieceAt(file, rank));
        board.clearPieces();
        assertNull(board.getPieceAt(file, rank));
    }

    @Test
    public void testArrangePieces() {

        BoardImpl board = getBoardImpl();
        board.arrangePieces();

        assertEquals(getChessFactory().newRook(Colour.Black), board.getPieceAt(File.FileA, Rank.Rank8));
        assertEquals(getChessFactory().newKnight(Colour.Black), board.getPieceAt(File.FileB, Rank.Rank8));
        assertEquals(getChessFactory().newBishop(Colour.Black), board.getPieceAt(File.FileC, Rank.Rank8));
        assertEquals(getChessFactory().newQueen(Colour.Black), board.getPieceAt(File.FileD, Rank.Rank8));
        assertEquals(getChessFactory().newKing(Colour.Black), board.getPieceAt(File.FileE, Rank.Rank8));
        assertEquals(getChessFactory().newBishop(Colour.Black), board.getPieceAt(File.FileF, Rank.Rank8));
        assertEquals(getChessFactory().newKnight(Colour.Black), board.getPieceAt(File.FileG, Rank.Rank8));
        assertEquals(getChessFactory().newRook(Colour.Black), board.getPieceAt(File.FileH, Rank.Rank8));

        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileA, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileB, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileC, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileD, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileE, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileF, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileG, Rank.Rank7));
        assertEquals(getChessFactory().newPawn(Colour.Black), board.getPieceAt(File.FileH, Rank.Rank7));

        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileA, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileB, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileC, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileD, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileE, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileF, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileG, Rank.Rank2));
        assertEquals(getChessFactory().newPawn(Colour.White), board.getPieceAt(File.FileH, Rank.Rank2));

        assertEquals(getChessFactory().newRook(Colour.White), board.getPieceAt(File.FileA, Rank.Rank1));
        assertEquals(getChessFactory().newKnight(Colour.White), board.getPieceAt(File.FileB, Rank.Rank1));
        assertEquals(getChessFactory().newBishop(Colour.White), board.getPieceAt(File.FileC, Rank.Rank1));
        assertEquals(getChessFactory().newQueen(Colour.White), board.getPieceAt(File.FileD, Rank.Rank1));
        assertEquals(getChessFactory().newKing(Colour.White), board.getPieceAt(File.FileE, Rank.Rank1));
        assertEquals(getChessFactory().newBishop(Colour.White), board.getPieceAt(File.FileF, Rank.Rank1));
        assertEquals(getChessFactory().newKnight(Colour.White), board.getPieceAt(File.FileG, Rank.Rank1));
        assertEquals(getChessFactory().newRook(Colour.White), board.getPieceAt(File.FileH, Rank.Rank1));
    }

    @Test
    public void testMovePiece() {
        Board board = getArrangedBoard();
        File fromFile = File.FileA;
        Rank fromRank = Rank.Rank7;
        File toFile = File.FileA;
        Rank toRank = Rank.Rank6;
        Piece fromPiece = board.getSquareAt(fromFile, fromRank).getPiece();
        Move move = getChessFactory().newMove(fromPiece.getClass(), fromFile, fromRank, toFile, toRank, false);
        board.movePiece(move);
        Piece toPiece = board.getSquareAt(toFile, toRank).getPiece();
        assertEquals(fromPiece, toPiece);
    }

}

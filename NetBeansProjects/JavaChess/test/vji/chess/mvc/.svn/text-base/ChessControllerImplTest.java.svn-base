package vji.chess.mvc;
import org.junit.Test;
import org.junit.Before;
import static org.junit.Assert.*;
import vji.chess.*;
import vji.mvc.*;
import vji.chess.test.*;

/**
 *
 * @author vji
 */
public class ChessControllerImplTest extends ChessTestCaseImpl {

    private ChessFactory _chessFactory;
    private ChessMvcFactory _chessMvcFactory;
    private Board _emptyBoard;
    private Board _arrangedBoard;
    private Board _board;
    private ChessController _chessController;

    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private void setChessMvcFactory(ChessMvcFactory factory) { _chessMvcFactory = factory; }
    private void setEmptyBoard(Board board) { _emptyBoard = board; }
    private void setArrangedBoard(Board board) { _arrangedBoard = board; }
    private void setBoard(Board board) { _board = board; }
    private void setChessController(ChessController controller) { _chessController = controller; }

    private ChessFactory getChessFactory() { return _chessFactory; }
    private ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }
    private Board getEmptyBoard() { return _emptyBoard; }
    private Board getArrangedBoard() { return _arrangedBoard; }
    private Board getBoard() { return _board; }
    private ChessController getChessController() { return _chessController; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
        setChessMvcFactory(new ChessMvcFactoryImpl());
        setEmptyBoard(getChessFactory().newBoard());
        setArrangedBoard(getChessFactory().newBoard());
        getArrangedBoard().arrangePieces();
        setBoard(getArrangedBoard());
        getBoard().arrangePieces();
        setChessController(getChessMvcFactory().newChessController(getBoard()));
    }
    
    @Test
    public void testProcess() {
        ArrangeCommand arrangeCommand = getChessMvcFactory().newArrangeCommand();
        ModelAndView modelAndView = getChessController().processArrangeCommand(arrangeCommand);
        assertNotNull(modelAndView);
        assertNotNull(modelAndView.getModel());
        assertNotNull(modelAndView.getViewName());
        assertEquals("boardView", modelAndView.getViewName());
        assertTrue(modelAndView.getModel() instanceof Board);
        Board board = (Board) modelAndView.getModel();
        
        Rank rank = Rank.Rank8;
        Colour colour = Colour.Black;
        assertPieceEquals(Rook.class, colour, board.getSquareAt(File.FileA, rank).getPiece());
        assertPieceEquals(Knight.class, colour, board.getSquareAt(File.FileB, rank).getPiece());
        assertPieceEquals(Bishop.class, colour, board.getSquareAt(File.FileC, rank).getPiece());
        assertPieceEquals(Queen.class, colour, board.getSquareAt(File.FileD, rank).getPiece());
        assertPieceEquals(King.class, colour, board.getSquareAt(File.FileE, rank).getPiece());
        assertPieceEquals(Bishop.class, colour, board.getSquareAt(File.FileF, rank).getPiece());
        assertPieceEquals(Knight.class, colour, board.getSquareAt(File.FileG, rank).getPiece());
        assertPieceEquals(Rook.class, colour, board.getSquareAt(File.FileH, rank).getPiece());

        rank = Rank.Rank7;
        for (File file : File.values) {
          assertPieceEquals(Pawn.class, colour, board.getSquareAt(file, rank).getPiece());
        }

        for (File file : File.values) {
            assertNull(board.getSquareAt(file, Rank.Rank6).getPiece());
            assertNull(board.getSquareAt(file, Rank.Rank5).getPiece());
            assertNull(board.getSquareAt(file, Rank.Rank4).getPiece());
            assertNull(board.getSquareAt(file, Rank.Rank3).getPiece());
        }

        rank = Rank.Rank2;
        colour = Colour.White;
        for (File file : File.values) {
          assertPieceEquals(Pawn.class, colour, board.getSquareAt(file, rank).getPiece());
        }

        rank = Rank.Rank1;
        assertPieceEquals(Rook.class, colour, board.getSquareAt(File.FileA, rank).getPiece());
        assertPieceEquals(Knight.class, colour, board.getSquareAt(File.FileB, rank).getPiece());
        assertPieceEquals(Bishop.class, colour, board.getSquareAt(File.FileC, rank).getPiece());
        assertPieceEquals(Queen.class, colour, board.getSquareAt(File.FileD, rank).getPiece());
        assertPieceEquals(King.class, colour, board.getSquareAt(File.FileE, rank).getPiece());
        assertPieceEquals(Bishop.class, colour, board.getSquareAt(File.FileF, rank).getPiece());
        assertPieceEquals(Knight.class, colour, board.getSquareAt(File.FileG, rank).getPiece());
        assertPieceEquals(Rook.class, colour, board.getSquareAt(File.FileH, rank).getPiece());
    }

    @Test
    public void testProcessMoveCommand() {
        ChessController controller = getChessController();
        Board board = getArrangedBoard();
        File fromFile = File.FileA;
        Rank fromRank = Rank.Rank7;
        File toFile = File.FileA;
        Rank toRank = Rank.Rank6;
        Piece fromPiece = board.getSquareAt(fromFile, fromRank).getPiece();
        Move move = getChessFactory().newMove(fromPiece.getClass(), fromFile, fromRank, toFile, toRank, false);
        MoveCommand moveCommand = getChessMvcFactory().newMoveCommand(move);
        controller.processMoveCommand(moveCommand);
        Piece toPiece = board.getSquareAt(toFile, toRank).getPiece();
        assertEquals(fromPiece, toPiece);
    }
}

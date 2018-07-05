package vji.chess.mvc;
import org.junit.Test;
import org.junit.Before;
import static org.junit.Assert.*;
import vji.chess.*;
import vji.mvc.*;
/**
 *
 * @author vji
 */
public class ChessMvcFactoryImplTest {

    private ChessFactory _chessFactory;
    private ChessMvcFactory _chessMvcFactory;
    private Board _board;
    
    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private void setChessMvcFactory(ChessMvcFactory factory) { _chessMvcFactory = factory; }
    private void setBoard(Board board) { _board = board; }

    private ChessFactory getChessFactory() { return _chessFactory; }
    private ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }
    private Board getBoard() { return _board; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
        setChessMvcFactory(new ChessMvcFactoryImpl());
        setBoard(getChessFactory().newBoard());
    }

    @Test
    public void testNewChessController() {
        ChessController chessController = getChessMvcFactory().newChessController(getBoard());
        assertNotNull(chessController);
        assertTrue(chessController instanceof ChessControllerImpl);
        ChessControllerImpl chessControllerImpl = (ChessControllerImpl) chessController;
        assertEquals(getChessMvcFactory(), chessControllerImpl.getFactory());
        assertEquals(getBoard(), chessControllerImpl.getBoard());
    }
    
    @Test
    public void testNewParser() {
        Parser parser = getChessMvcFactory().newParser(getChessFactory());
        assertNotNull(parser);
        assertTrue(parser instanceof ParserImpl);
        ParserImpl parserImpl = (ParserImpl) parser;
        assertEquals(getChessMvcFactory(), parserImpl.getChessMvcFactory());
    }

    @Test
    public void testNewBoardView() {
        View view = getChessMvcFactory().newBoardView();
        assertNotNull(view);
        assertTrue(view instanceof BoardViewImpl);
    }

    @Test
    public void testNewStartBoardView() {
        View view = getChessMvcFactory().newStartBoardView();
        assertNotNull(view);
        assertTrue(view instanceof StartBoardViewImpl);
    }

    @Test
    public void testNewUnknownCommand() {
        UnknownCommand command = getChessMvcFactory().newUnknownCommand("garbled command");
        assertNotNull(command);
        assertEquals("garbled command", command.getCommandString());
        assertTrue(command instanceof UnknownCommandImpl);
    }

    @Test
    public void testNewArrangeCommand() {
        ArrangeCommand command = getChessMvcFactory().newArrangeCommand();
        assertNotNull(command);
        assertTrue(command instanceof ArrangeCommandImpl);
    }

    @Test
    public void testNewMoveCommand() {
        Move move = getChessFactory().newMove(Pawn.class, File.FileA, Rank.Rank1, File.FileA, Rank.Rank1, false);
        MoveCommand command = getChessMvcFactory().newMoveCommand(move);
        assertNotNull(command);
        assertTrue(command instanceof MoveCommandImpl);
        assertEquals(move, command.getMove());
    }
}

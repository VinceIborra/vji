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
public class ArrangeCommandImplTest {

    private ChessFactory _chessFactory;
    private ChessMvcFactory _mockChessMvcFactory;
    private ChessMvcFactory _chessMvcFactory;
    private Board _board;

    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private void setMockChessMvcFactory(ChessMvcFactory factory) { _mockChessMvcFactory = factory; }
    private void setChessMvcFactory(ChessMvcFactory factory) { _chessMvcFactory = factory; }
    private void setBoard(Board board) { _board = board; }

    private ChessFactory getChessFactory() { return _chessFactory; }
    private ChessMvcFactory getMockChessMvcFactory() { return _mockChessMvcFactory; }
    private ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }
    private Board getBoard() { return _board; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
        setMockChessMvcFactory(new MockChessMvcFactoryImpl());
        setChessMvcFactory(new ChessMvcFactoryImpl());
        setBoard(getChessFactory().newBoard());
    }
    
    @Test
    public void testProcess() {
        Controller controller = getMockChessMvcFactory().newChessController(getBoard());
        MockChessControllerImpl mockController = (MockChessControllerImpl) controller;
        ArrangeCommand command = getChessMvcFactory().newArrangeCommand();
        command.process(controller);
        assertTrue(mockController.isBoardArranged());
    }
}
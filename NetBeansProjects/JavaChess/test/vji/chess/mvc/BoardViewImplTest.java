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
public class BoardViewImplTest {

    private ChessFactory _chessFactory;
    private ChessMvcFactory _chessMvcFactory;
    private Board _board;
    private View _view;
    private BoardViewImpl _viewImpl;

    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private void setChessMvcFactory(ChessMvcFactory factory) { _chessMvcFactory = factory; }
    private void setBoard(Board board) { _board = board; }
    private void setView(View view) { _view = view; }
    private void setViewImpl(BoardViewImpl viewImpl) { _viewImpl = viewImpl; }

    private ChessFactory getChessFactory() { return _chessFactory; }
    private ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }
    private Board getBoard() { return _board; }
    private View getView() { return _view; }
    private BoardViewImpl getViewImpl() { return _viewImpl; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
        setChessMvcFactory(new ChessMvcFactoryImpl());
        setBoard(getChessFactory().newBoard());
        setView(getChessMvcFactory().newBoardView());
        setViewImpl((BoardViewImpl) getView());
    }


    @Test
    public void testRenderPrompt() {
        String text = getViewImpl().renderPrompt();
        assertEquals("> ", text);
    }

    @Test
    public void testRenderEmptyBoard() {
        String text = getViewImpl().renderBoard(getBoard());
        assertEquals(
            "\n" +
            "     A   B   C   D   E   F   G   H\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "8  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "7  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "6  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "5  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "4  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "3  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "2  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "1  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "\n",
            text
      );
    }
    
    @Test
    public void testArrangedBoard() {
        getBoard().arrangePieces();
        String text = getViewImpl().renderBoard(getBoard());
        assertEquals(
            "\n" +
            "     A   B   C   D   E   F   G   H\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "8  | R |-N-| B |-Q-| K |-B-| N |-R-|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "7  |-P-| P |-P-| P |-P-| P |-P-| P |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "6  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "5  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "4  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "3  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "2  | p |-p-| p |-p-| p |-p-| p |-p-|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "1  |-r-| n |-b-| q |-k-| b |-n-| r |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "\n",
            text
        );
    }

    @Test
    public void testRender() {
        getBoard().arrangePieces();
        String text = getView().render(getBoard());
        assertEquals(
            "\n" +
            "     A   B   C   D   E   F   G   H\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "8  | R |-N-| B |-Q-| K |-B-| N |-R-|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "7  |-P-| P |-P-| P |-P-| P |-P-| P |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "6  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "5  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "4  |   |---|   |---|   |---|   |---|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "3  |---|   |---|   |---|   |---|   |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "2  | p |-p-| p |-p-| p |-p-| p |-p-|\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "1  |-r-| n |-b-| q |-k-| b |-n-| r |\n" +
            "   +---+---+---+---+---+---+---+---+\n" +
            "\n" +
            "> ",
            text
        );
    }
}


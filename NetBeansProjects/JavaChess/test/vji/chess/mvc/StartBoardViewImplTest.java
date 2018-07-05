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
public class StartBoardViewImplTest {

    private ChessFactory _chessFactory;
    private ChessMvcFactory _chessMvcFactory;
    private Board _board;
    private View _view;    private StartBoardViewImpl _viewImpl;

    private void setChessFactory(ChessFactory factory) { _chessFactory = factory; }
    private void setChessMvcFactory(ChessMvcFactory factory) { _chessMvcFactory = factory; }
    private void setBoard(Board board) { _board = board; }
    private void setView(View view) { _view = view; }
    private void setViewImpl(StartBoardViewImpl viewImpl) { _viewImpl = viewImpl; }

    private ChessFactory getChessFactory() { return _chessFactory; }
    private ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }
    private Board getBoard() { return _board; }
    private View getView() { return _view; }
    private StartBoardViewImpl getViewImpl() { return _viewImpl; }

    @Before
    public void setUp() {
        setChessFactory(new ChessFactoryImpl());
        setChessMvcFactory(new ChessMvcFactoryImpl());
        setBoard(getChessFactory().newBoard());
        setView(getChessMvcFactory().newStartBoardView());
        setViewImpl((StartBoardViewImpl) getView());
    }

    @Test
    public void testRenderIntro() {
        String text = getViewImpl().renderIntro();
        assertEquals(
            "\n" +
            "Commands:\n" +
            "\n" +
            "  Move A Piece:\n" +
            "    <piece><from_file><from_rank>[<capture>]<to_file><to_rank>\n" +
            "\n" +
            "    piece   - p,r,n,b,q,k\n" +
            "    file    - a,b,c,d,e,f,g,h\n" +
            "    rank    - 1,2,3,4,5,6,7,8\n" +
            "    capture - x\n" +
            "\n" +
            "  Other:\n" +
            "    exit - to exit\n" +
            "\n",
            text
        );

    }
    
    @Test
    public void testRender() {
        Board board = getBoard();
        board.arrangePieces();
        String text = getView().render(board);
        assertEquals(
            "\n" +
            "Commands:\n" +
            "\n" +
            "  Move A Piece:\n" +
            "    <piece><from_file><from_rank>[<capture>]<to_file><to_rank>\n" +
            "\n" +
            "    piece   - p,r,n,b,q,k\n" +
            "    file    - a,b,c,d,e,f,g,h\n" +
            "    rank    - 1,2,3,4,5,6,7,8\n" +
            "    capture - x\n" +
            "\n" +
            "  Other:\n" +
            "    exit - to exit\n" +
            "\n" +
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


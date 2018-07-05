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
public class ParserImplTest {

    private ChessMvcFactory _chessMvcFactory;
    private ChessFactory _chessFactory;
    private Parser _parser;

    private void setChessMvcFactory(ChessMvcFactory factory) { _chessMvcFactory = factory; }
    private void setChessFactory(ChessFactory chessFactory) { _chessFactory = chessFactory; }
    private void setParser(Parser parser) { _parser = parser; }

    private ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }
    private ChessFactory getChessFactory() { return _chessFactory; }
    private Parser getParser() { return _parser; }

    @Before
    public void setUp() {
        setChessMvcFactory(new ChessMvcFactoryImpl());
        setChessFactory(new ChessFactoryImpl());
        setParser(getChessMvcFactory().newParser(getChessFactory()));
    }
    
    @Test
    public void testParseArrageCommand() {
        String str = "arrange";
        Command command = getParser().parse(str);
        assertNotNull(command);
        assertTrue(command instanceof ArrangeCommand);
    }

    @Test
    public void testParseExitCommand() {
        String str = "exit";
        Command command = getParser().parse(str);
        assertNotNull(command);
        assertTrue(command instanceof AppEndCommand);
    }

    @Test
    public void testParseMoveCommand() {
      String str = "pa2a3";
      Command command = getParser().parse(str);
      assertNotNull(command);
      assertTrue(command instanceof MoveCommand);
      MoveCommand moveCommand = (MoveCommand) command;
      assertNotNull(moveCommand.getMove());
      assertEquals(Pawn.class, moveCommand.getMove().getPieceType());
      assertEquals(Rank.Rank2, moveCommand.getMove().getFromRank());
      assertEquals(File.FileA, moveCommand.getMove().getFromFile());
      assertEquals(Rank.Rank3, moveCommand.getMove().getToRank());
      assertEquals(File.FileA, moveCommand.getMove().getToFile());
      assertEquals(false, moveCommand.getMove().getCapture());
    }
}
//
//
//    def test_parse_non_command
//      str = "a rubbish string"
//      command = parser.parse(str)
//      assert_not_nil(command)
//      assert_kind_of(Command, command)
//      assert_kind_of(NonCommand, command)
//      assert_equal("Could not parse command <a rubbish string>.", command.message)
//    end
//  end
//end


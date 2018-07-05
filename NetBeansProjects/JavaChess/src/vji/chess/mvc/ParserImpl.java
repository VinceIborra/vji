package vji.chess.mvc;
import java.util.regex.*;
import vji.chess.*;
import vji.mvc.*;

/**
 *
 * @author vji
 */
public class ParserImpl implements Parser {

    private static final String _ARRANGE_EXPR = "^arrange$";
    private static final String _MOVE_EXPR = "^([prnbqk])([a-h])([1-8])(x?)([a-h])([1-8])$";
    private static final String _EXIT_EXPR = "^exit$";

    private Pattern _arrangePattern;
    private Pattern _movePattern;
    private Pattern _exitPattern;
    private ChessFactory _chessFactory;
    private ChessMvcFactory _chessMvcFactory;

    private void setArrangePattern(Pattern pattern) {  _arrangePattern = pattern; }
    private void setMovePattern(Pattern pattern) {  _movePattern = pattern; }
    private void setExitPattern(Pattern pattern) {  _exitPattern = pattern; }
    public void setChessFactory(ChessFactory factory) {  _chessFactory = factory; }
    public void setChessMvcFactory(ChessMvcFactory factory) {  _chessMvcFactory = factory; }

    private Pattern getArrangePattern() { return _arrangePattern; }
    private Pattern getMovePattern() { return _movePattern; }
    private Pattern getExitPattern() { return _exitPattern; }
    public ChessFactory getChessFactory() { return _chessFactory; }
    public ChessMvcFactory getChessMvcFactory() { return _chessMvcFactory; }

    ParserImpl() {
        setArrangePattern(Pattern.compile(_ARRANGE_EXPR));
        setMovePattern(Pattern.compile(_MOVE_EXPR));
        setExitPattern(Pattern.compile(_EXIT_EXPR));
    }

    public Command parse(String message) {

        // Normalise to lower case
        String msg = message.trim().toLowerCase();

        // Arrange command
        Matcher arrangeMatcher = getArrangePattern().matcher(msg);
        if (arrangeMatcher.matches()) {
            return getChessMvcFactory().newArrangeCommand();
        }

        // Move command
        Matcher moveMatcher = getMovePattern().matcher(msg);
        if (moveMatcher.matches()) {

            // Piece class
            Class pieceType = null;
            if (moveMatcher.group(1).equals("p"))
                pieceType = Pawn.class;
            else if(moveMatcher.group(1).equals("r"))
                pieceType = Rook.class;
            else if(moveMatcher.group(1).equals("n"))
                pieceType = Knight.class;
            else if(moveMatcher.group(1).equals("b"))
                pieceType = Bishop.class;
            else if(moveMatcher.group(1).equals("q"))
                pieceType = Queen.class;
            else if(moveMatcher.group(1).equals("k"))
                pieceType = King.class;

            // From location
            File fromFile = File.fromString(moveMatcher.group(2));
            Rank fromRank = Rank.fromString(moveMatcher.group(3));

            // Capture
            boolean capture = false;
            if (moveMatcher.group(4).equals("x")) {
                capture = true;
            }

            // To location
            File toFile = File.fromString(moveMatcher.group(5));
            Rank toRank = Rank.fromString(moveMatcher.group(6));
            
            // Create move
            Move move = getChessFactory().newMove(pieceType, fromFile, fromRank, toFile, toRank, capture);

            // Create and return the corresponding command
            return getChessMvcFactory().newMoveCommand(move);
        }

        // Exit command
        Matcher exitMatcher = getExitPattern().matcher(msg);
        if (exitMatcher.matches()) {
            return getChessMvcFactory().newAppEndCommand();
        }

        // Unknown Command
        return getChessMvcFactory().newUnknownCommand("Could not parse command \"" + message + "\".");
    }
}

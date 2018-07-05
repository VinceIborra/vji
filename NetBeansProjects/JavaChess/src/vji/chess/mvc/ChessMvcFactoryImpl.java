package vji.chess.mvc;
import vji.mvc.*;
import vji.chess.*;

/**
 *
 * @author vji
 */
public class ChessMvcFactoryImpl extends vji.mvc.FactoryImpl implements ChessMvcFactory  {

    @Override
    public ChessController newChessController(Board board) {
        ChessControllerImpl controller = new ChessControllerImpl();
        controller.setFactory(this);
        controller.setBoard(board);
        return controller;
    }

    @Override
    public ArrangeCommand newArrangeCommand() {
        ArrangeCommandImpl command = new ArrangeCommandImpl();
        return command;
    }

    @Override
    public MoveCommand newMoveCommand(Move move) {
        MoveCommandImpl moveCommand = new MoveCommandImpl();
        moveCommand.setMove(move);
        return moveCommand;
    }

    @Override
    public UnknownCommand newUnknownCommand(String commandString) {
        UnknownCommandImpl command = new UnknownCommandImpl();
        command.setCommandString(commandString);
        return command;
    }

    @Override
    public Parser newParser(ChessFactory chessFactory) {
        ParserImpl parser = new ParserImpl();
        parser.setChessFactory(chessFactory);
        parser.setChessMvcFactory(this);
        return parser;
    }

    @Override
    public View newBoardView() {
        BoardViewImpl view = new BoardViewImpl();
        return view;
    }

    @Override
    public View newStartBoardView() {
        StartBoardViewImpl view = new StartBoardViewImpl();
        return view;
    }

}

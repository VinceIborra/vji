package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface RoverController {
    void processCommand(Command command);
    void processCommand(PlateauChangeCommand command);
    void processCommand(RoverStartCommand command);
    void processCommand(RoverTurnLeftCommand command);
    void processCommand(RoverTurnRightCommand command);
    void processCommand(RoverMoveCommand command);
}

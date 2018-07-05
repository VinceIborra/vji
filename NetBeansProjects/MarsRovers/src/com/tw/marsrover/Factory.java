package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface Factory {

    public CommandParser newCommandParser(Factory factory);

    public Plateau newPlateau();
    public Plateau newPlateau(int x, int y);

    public RoverController newRoverController(Factory factory, Plateau plateau);

    public PlateauRenderer newPlateauRenderer(Plateau plateau);

    public PlateauChangeCommand newPlateauChangeCommand(int x, int y);
    public RoverStartCommand newRoverStartCommand(int x, int y, Orientation orientation);
    public RoverChangeCommand newRoverChangeCommand(RoverChangeEnum command);

    PositionAndOrientation newPositionAndOrientation(int x, int y, Orientation orientation);

    Rover newRover(Plateau plateau, int x, int y, Orientation orientation);
    Rover newRover(Plateau plateau, PositionAndOrientation positionAndOrientation);
    Rover newRover(Factory factory, Plateau plateau, PositionAndOrientation positionAndOrientation);
    public Beacon newBeacon(PositionAndOrientation positionAndOrientation);

}

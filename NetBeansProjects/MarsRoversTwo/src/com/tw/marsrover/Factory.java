package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface Factory {

    public CommandParser newAnonymousRoverCommandParser(Factory factory);
    public CommandParser newNamedRoverCommandParser(Factory factory);

    public Plateau newPlateau();
    public Plateau newPlateau(int x, int y);

    public PlateauEntityRepository newPlateauEntityRepository();

    public RoverController newRoverController(Factory factory, Plateau plateau, PlateauEntityRepository repository, RoverLogger logger);

    public PlateauAndRoversRenderer newPlateauAndRoversRenderer(Plateau plateau, PlateauEntityRepository repository);
    public PlateauAndRoversRenderer newAsciiArtPlateauAndRoversRenderer(Plateau plateau, PlateauEntityRepository repository);

    public PlateauChangeCommand newPlateauChangeCommand(int x, int y);
    public RoverStartCommand newRoverStartCommand(String name, int x, int y, Orientation orientation);
    public RoverChangeCommand newRoverChangeCommand(String name, RoverChangeEnum command);

    PositionAndOrientation newPositionAndOrientation(int x, int y, Orientation orientation);

    Rover newRover(Factory factory, Plateau plateau, PlateauEntityRepository repository, String name, PositionAndOrientation positionAndOrientation);

    Beacon newBeacon(int x, int y, Orientation orientation);
    Beacon newBeacon(PositionAndOrientation positionAndOrientation);

    RoverAppDriver newFileRoverAppDriver(String []args, CommandParser parser, RoverController controller, PlateauAndRoversRenderer renderer    );
    RoverAppDriver newInteractiveRoverAppDriver(String []args, CommandParser parser, RoverController controller, PlateauAndRoversRenderer renderer    );

    RoverLogger newRoverLogger(String fileName);
}

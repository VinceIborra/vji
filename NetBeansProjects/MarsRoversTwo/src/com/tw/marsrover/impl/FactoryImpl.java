package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class FactoryImpl implements Factory {

    public CommandParser newAnonymousRoverCommandParser(Factory factory) {
        AnonymousRoverCommandParserImpl commandParser = new AnonymousRoverCommandParserImpl();
        commandParser.setFactory(factory);
        return commandParser;
    }
    public CommandParser newNamedRoverCommandParser(Factory factory) {
        NamedRoverCommandParserImpl commandParser = new NamedRoverCommandParserImpl();
        commandParser.setFactory(factory);
        return commandParser;
    }

    public Plateau newPlateau() {
        PlateauImpl plateau = new PlateauImpl();
        return plateau;
    }

    public Plateau newPlateau(int x, int y) {
        PlateauImpl plateau = new PlateauImpl();
        plateau.setX(x);
        plateau.setY(y);
        return plateau;
    }

    public PlateauEntityRepository newPlateauEntityRepository() {
        PlateauEntityRepositoryImpl repository = new PlateauEntityRepositoryImpl();
        return repository;
    }
    
    public RoverController newRoverController(Factory factory, Plateau plateau, PlateauEntityRepository repository, RoverLogger logger) {
        RoverControllerImpl roverController = new RoverControllerImpl();
        roverController.setFactory(factory);
        roverController.setPlateau(plateau);
        roverController.setRoverRepository(repository);
        roverController.setRoverLogger(logger);
        return roverController;
    }

    public PlateauAndRoversRenderer newPlateauAndRoversRenderer(Plateau plateau, PlateauEntityRepository repository) {
        PlateauAndRoversRendererImpl renderer = new PlateauAndRoversRendererImpl();
        renderer.setPlateau(plateau);
        renderer.setRoverRepository(repository);
        return renderer;
    }

    public PlateauAndRoversRenderer newAsciiArtPlateauAndRoversRenderer(Plateau plateau, PlateauEntityRepository repository) {
        AsciiArtPlateauAndRoversRendererImpl renderer = new AsciiArtPlateauAndRoversRendererImpl();
        renderer.setPlateau(plateau);
        renderer.setRoverRepository(repository);
        return renderer;
    }

    public PlateauChangeCommand newPlateauChangeCommand(int x, int y) {
        PlateauChangeCommandImpl command = new PlateauChangeCommandImpl();
        command.setX(x);
        command.setY(y);
        return command;
    }
    public RoverStartCommand newRoverStartCommand(String name, int x, int y, Orientation orientation) {
        RoverStartCommandImpl command = new RoverStartCommandImpl();
        command.setName(name);
        command.setX(x);
        command.setY(y);
        command.setOrientation(orientation);
        return command;
    }
    public RoverChangeCommand newRoverChangeCommand(String name, RoverChangeEnum command) {
        RoverChangeCommandImpl cmd = null;
        switch(command) {
            case Left:  cmd = new RoverTurnLeftCommandImpl();  break;
            case Right: cmd = new RoverTurnRightCommandImpl(); break;
            case Move:  cmd = new RoverMoveCommandImpl();      break;
        }
        cmd.setName(name);
        return cmd;
    }

    public PositionAndOrientation newPositionAndOrientation(int x, int y, Orientation orientation) {
        PositionAndOrientationImpl positionAndImplementation = new PositionAndOrientationImpl();
        positionAndImplementation.setX(x);
        positionAndImplementation.setY(y);
        positionAndImplementation.setOrientation(orientation);
        return positionAndImplementation;
    }

    public Rover newRover(
        Factory factory,
        Plateau plateau,
        PlateauEntityRepository repository,
        String name,
        PositionAndOrientation positionAndOrientation
    ) {
      RoverImpl rover = new RoverImpl();
      rover.setFactory(factory);
      rover.setPlateau(plateau);
      rover.setRoverRepository(repository);
      rover.setName(name);
      rover.setPositionAndOrientation(positionAndOrientation);
      return rover;
    }

    public Beacon newBeacon(int x, int y, Orientation orientation) {
        BeaconImpl beacon = new BeaconImpl();
        PositionAndOrientation positionAndOrientation = newPositionAndOrientation(x, y, orientation);
        beacon.setPositionAndOrientation(positionAndOrientation);
        return beacon;
    }

    public Beacon newBeacon(PositionAndOrientation positionAndOrientation) {
        BeaconImpl beacon = new BeaconImpl();
        beacon.setPositionAndOrientation(positionAndOrientation);
        return beacon;
    }

    public RoverAppDriver newFileRoverAppDriver(
        String[] args,
        CommandParser parser,
        RoverController controller,
        PlateauAndRoversRenderer renderer
    ) {
        FileRoverAppDriverImpl driver = new FileRoverAppDriverImpl();
        driver.setArgs(args);
        driver.setParser(parser);
        driver.setController(controller);
        driver.setRenderer(renderer);
        return driver;
    }

    public RoverAppDriver newInteractiveRoverAppDriver(
        String[] args,
        CommandParser parser,
        RoverController controller,
        PlateauAndRoversRenderer renderer
    ) {
        InteractiveRoverAppDriverImpl driver = new InteractiveRoverAppDriverImpl();
        driver.setArgs(args);
        driver.setParser(parser);
        driver.setController(controller);
        driver.setRenderer(renderer);
        return driver;
    }

    public RoverLogger newRoverLogger(String fileName) {
        RoverLoggerImpl logger = new RoverLoggerImpl();
        logger.setFileName(fileName);
        return logger;
    }




}

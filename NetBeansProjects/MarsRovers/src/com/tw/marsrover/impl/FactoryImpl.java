package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class FactoryImpl implements Factory {

    public CommandParser newCommandParser(Factory factory) {
        CommandParserImpl commandParser = new CommandParserImpl();
        commandParser.setFactory(factory);
        return commandParser;
    }

    public Plateau newPlateau() {
        PlateauImpl plateau = new PlateauImpl();
        return plateau;
    }

    public Plateau newPlateau(int x, int y) {
        Plateau plateau = newPlateau();
        plateau.setX(x);
        plateau.setY(y);
        return plateau;
    }
    
    public RoverController newRoverController(Factory factory, Plateau plateau) {
        RoverControllerImpl roverController = new RoverControllerImpl();
        roverController.setFactory(factory);
        roverController.setPlateau(plateau);
        return roverController;
    }

    public PlateauRenderer newPlateauRenderer(Plateau plateau) {
        PlateauRendererImpl plateauRenderer = new PlateauRendererImpl();
        plateauRenderer.setPlateau(plateau);
        return plateauRenderer;
    }

    public PlateauChangeCommand newPlateauChangeCommand(int x, int y) {
        PlateauChangeCommandImpl command = new PlateauChangeCommandImpl();
        command.setX(x);
        command.setY(y);
        return command;
    }
    public RoverStartCommand newRoverStartCommand(int x, int y, Orientation orientation) {
        RoverStartCommandImpl command = new RoverStartCommandImpl();
        command.setX(x);
        command.setY(y);
        command.setOrientation(orientation);
        return command;
    }
    public RoverChangeCommand newRoverChangeCommand(RoverChangeEnum command) {
        RoverChangeCommand cmd = null;
        switch(command) {
            case Left:  cmd = new RoverTurnLeftCommandImpl();  break;
            case Right: cmd = new RoverTurnRightCommandImpl(); break;
            case Move:  cmd = new RoverMoveCommandImpl();      break;
        }
        return cmd;
    }

    public PositionAndOrientation newPositionAndOrientation(int x, int y, Orientation orientation) {
        PositionAndOrientationImpl positionAndImplementation = new PositionAndOrientationImpl();
        positionAndImplementation.setX(x);
        positionAndImplementation.setY(y);
        positionAndImplementation.setOrientation(orientation);
        return positionAndImplementation;
    }

    public Rover newRover(Factory factory, Plateau plateau, PositionAndOrientation positionAndOrientation) {
      RoverImpl rover = new RoverImpl();
      rover.setFactory(factory);
      rover.setPlateau(plateau);
      rover.setPositionAndOrientation(positionAndOrientation);
      return rover;
    }

    public Rover newRover(Plateau plateau, int x, int y, Orientation orientation) {
        PositionAndOrientation pao = newPositionAndOrientation(x, y, orientation);
        RoverImpl rover = new RoverImpl();
        rover.setFactory(this);
        rover.setPlateau(plateau);
        rover.setPositionAndOrientation(pao);
        return rover;
    }

    public Rover newRover(Plateau plateau, PositionAndOrientation positionAndOrientation) {
        return newRover(this, plateau, positionAndOrientation);
    }


    public Beacon newBeacon(PositionAndOrientation positionAndOrientation) {
        BeaconImpl beacon = new BeaconImpl();
        beacon.setPositionAndOrientation(positionAndOrientation);
        return beacon;
    }

}

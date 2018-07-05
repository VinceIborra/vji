package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverControllerImpl implements RoverController {

    Factory factory;
    Plateau plateau;

    public void setFactory(Factory factory) {
        this.factory = factory;
    }

    public Factory getFactory() {
        return this.factory;
    }

    public void setPlateau(Plateau plateau) {
        this.plateau = plateau;
    }

    public Plateau getPlateau() {
        return this.plateau;
    }

    public void processCommand(Command command) {
        if (command instanceof PlateauChangeCommand) {
            this.processPlateauChangeCommand((PlateauChangeCommand) command);
        }
        else if (command instanceof RoverStartCommand) {
            this.processRoverStartCommand((RoverStartCommand) command);
        }
        else if (command instanceof RoverChangeCommand) {
            this.processRoverChangeCommand((RoverChangeCommand) command);
        }
    }

    private void processPlateauChangeCommand(PlateauChangeCommand command) {
        this.plateau.setX(command.getX());
        this.plateau.setY(command.getY());
    }
    private void processRoverStartCommand(RoverStartCommand command) {
        PositionAndOrientation positionAndOrientation = this.factory.newPositionAndOrientation(
            command.getX(),
            command.getY(),
            command.getOrientation()
        );
        Rover newRover = this.getFactory().newRover(this.getFactory(), this.getPlateau(), positionAndOrientation);
        this.getPlateau().startNewRover(newRover);
    }
    private void processRoverChangeCommand(RoverChangeCommand command) {
        if (this.plateau.getCurrentRover() == null) {
            throw new CurrentRoverNotSetException("");
        }
        if (command instanceof RoverTurnLeftCommand) {
            this.plateau.getCurrentRover().turnLeft();
        }
        else if (command instanceof RoverTurnRightCommand) {
            this.plateau.getCurrentRover().turnRight();
        }
        else if (command instanceof RoverMoveCommand) {
            this.plateau.getCurrentRover().move();
        }
    }
}

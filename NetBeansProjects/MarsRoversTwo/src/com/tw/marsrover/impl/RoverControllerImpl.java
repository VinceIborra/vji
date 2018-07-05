package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverControllerImpl implements RoverController {

    Factory factory;
    Plateau plateau;
    PlateauEntityRepository repository;
    RoverLogger logger;

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

    public void setRoverRepository(PlateauEntityRepository repository) {
        this.repository = repository;
    }

    public PlateauEntityRepository getRoverRepository() {
        return this.repository;
    }

    public void setRoverLogger(RoverLogger logger) {
        this.logger = logger;
    }

    public RoverLogger getRoverLogger() {
        return this.logger;
    }

    public void processCommand(Command command) {
        command.process(this);
    }

    public void processCommand(PlateauChangeCommand command) {
        this.plateau.setX(command.getX());
        this.plateau.setY(command.getY());
    }
    public void processCommand(RoverStartCommand command) {
        PositionAndOrientation positionAndOrientation = this.factory.newPositionAndOrientation(
            command.getX(),
            command.getY(),
            command.getOrientation()
        );
        Rover newRover = this.getFactory().newRover(
            this.getFactory(),
            this.getPlateau(),
            this.getRoverRepository(),
            command.getName(),
            positionAndOrientation
        );
        this.getRoverRepository().startNewRover(newRover);
        this.getRoverLogger().log("New rover created - " + newRover.getName());
    }
    public void processCommand(RoverTurnLeftCommand command) {
        this.findRoverByName(command.getName()).turnLeft();
        this.getRoverLogger().log("Rover turned left - " + command.getName());
    }
    public void processCommand(RoverTurnRightCommand command) {
        this.findRoverByName(command.getName()).turnRight();
        this.getRoverLogger().log("Rover turned right - " + command.getName());
    }
    public void processCommand(RoverMoveCommand command) {
        this.findRoverByName(command.getName()).move();
        this.getRoverLogger().log("Rover moved - " + command.getName());
    }

    private Rover findRoverByName(String name) {
        Rover rover = this.getRoverRepository().findRoverByName(name);
        if (rover == null) {
            throw new CurrentRoverNotSetException("");
        }
        return rover;
    }

}

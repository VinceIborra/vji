package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverImpl implements Rover {

    private Factory factory;
    private Plateau plateau;
    private PlateauEntityRepository repository;
    String name;
    private PositionAndOrientation positionAndOrientation;

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

    public void setPositionAndOrientation(PositionAndOrientation positionAndOrientation) {
        this.positionAndOrientation = positionAndOrientation;
    }
    public PositionAndOrientation getPositionAndOrientation() {
        return this.positionAndOrientation;
    }

    public void setName(String name) {
        this.name = name;
    }
    public String getName() {
        return this.name;
    }

    public void turnLeft() {

        // Calculate new orientation
        Orientation newOrientation = this.getPositionAndOrientation().getOrientation();
        switch(this.getPositionAndOrientation().getOrientation()) {
            case North: newOrientation = Orientation.West;  break;
            case West:  newOrientation = Orientation.South; break;
            case South: newOrientation = Orientation.East;  break;
            case East:  newOrientation = Orientation.North; break;
            default:    new UnsupportedOperationException("Invalid orientation"); break;
        }

        // Calculate a new composite position and orientation
        PositionAndOrientation newPositionAndOrientation = factory.newPositionAndOrientation(
                this.getPositionAndOrientation().getX(),
                this.getPositionAndOrientation().getY(),
                newOrientation
        );

        // If assertion did not fail, then we can set the new position and orientation
        this.setPositionAndOrientation(newPositionAndOrientation);
    }

    public void turnRight() {

        // Calculate new orientation
        Orientation newOrientation = this.getPositionAndOrientation().getOrientation();
        switch(this.getPositionAndOrientation().getOrientation()) {
            case North: newOrientation = Orientation.East;  break;
            case East:  newOrientation = Orientation.South; break;
            case South: newOrientation = Orientation.West;  break;
            case West:  newOrientation = Orientation.North; break;
            default:    new UnsupportedOperationException("Invalid orientation"); break;
        }

        // Calculate a new composite position and orientation
        PositionAndOrientation newPositionAndOrientation = factory.newPositionAndOrientation(
                this.getPositionAndOrientation().getX(),
                this.getPositionAndOrientation().getY(),
                newOrientation
        );

        // If assertion did not fail, then we can set the new position and orientation
        this.setPositionAndOrientation(newPositionAndOrientation);
    }

    public void move() {
        
        // Cannot move if a beacon is present
        assertBeaconNotPresentAtCurrentLocation();

        // Calculate new position
        int newX = this.getPositionAndOrientation().getX();
        int newY = this.getPositionAndOrientation().getY();
        switch(this.getPositionAndOrientation().getOrientation()) {
            case North: newY++; break;
            case East:  newX++; break;
            case South: newY--;  break;
            case West:  newX--;
            default:    new UnsupportedOperationException("Invalid orientation"); break;
        }

        // Calculate a new composite position and orientation
        PositionAndOrientation newPositionAndOrientation = factory.newPositionAndOrientation(
                newX,
                newY,
                this.getPositionAndOrientation().getOrientation()
        );

        // Validate move
        assertCollisionNotImminent(newPositionAndOrientation);

        // Leave a beacon if we've gone over the edge
        if (!plateau.isPositionInPlateau(newPositionAndOrientation.getX(), newPositionAndOrientation.getY())){
            Beacon beacon = factory.newBeacon(getPositionAndOrientation());
            repository.place(beacon);
        }

        // If assertion did not fail, then we can set the new position and orientation
        this.setPositionAndOrientation(newPositionAndOrientation);

    }

    private void assertBeaconNotPresentAtCurrentLocation() {
        Beacon beacon = repository.findBeaconByCoords(positionAndOrientation.getX(), positionAndOrientation.getY());
        if (beacon != null && beacon.getPositionAndOrientation().getOrientation().equals(positionAndOrientation.getOrientation())) {
            throw new CannotMoveBeaconPresentException("");
        }
    }

    private void assertCollisionNotImminent(PositionAndOrientation positionAndOrientation) {
        for (Rover rover : this.getRoverRepository().getRovers()) {
            if (rover != this
            &&  rover.getPositionAndOrientation().getX() == positionAndOrientation.getX()
            &&  rover.getPositionAndOrientation().getY() == positionAndOrientation.getY()) {
                throw new ImminentCollisionException("");
            }
        }
    }

}

package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverImpl implements Rover {

    private Factory factory;
    private Plateau plateau;
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

    public void setPositionAndOrientation(PositionAndOrientation positionAndOrientation) {
        this.positionAndOrientation = positionAndOrientation;
    }
    public PositionAndOrientation getPositionAndOrientation() {
        return this.positionAndOrientation = positionAndOrientation;
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

        // Validate it
        plateau.assertValidPositionAndOrientation(newPositionAndOrientation);

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

        // Validate it
        plateau.assertValidPositionAndOrientation(newPositionAndOrientation);

        // If assertion did not fail, then we can set the new position and orientation
        this.setPositionAndOrientation(newPositionAndOrientation);
    }

    public void move() {

        // Ignore order if being asked to move in the same direction as indicated by a beacon
        PositionAndOrientation pao = getPositionAndOrientation();
        Beacon beacon = plateau.findBeaconAt(pao.getX(), pao.getY());
        if (beacon != null && beacon.getPositionAndOrientation().equals(pao)) {
            return;
        }

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

        // Calculate a new composite position and orientation, and keep the old one
        PositionAndOrientation newPositionAndOrientation = factory.newPositionAndOrientation(
                newX,
                newY,
                this.getPositionAndOrientation().getOrientation()
        );
        PositionAndOrientation oldPositionAndOrientation = this.getPositionAndOrientation();

        // Set new position
        this.setPositionAndOrientation(newPositionAndOrientation);

        // Check whether to see if we have gone over the edge, and leave a beacon if we have
        if (!isRoverInPlateau()) {
            beacon = factory.newBeacon(oldPositionAndOrientation);
            plateau.place(beacon);
        }
    }

    public boolean isRoverInPlateau() {
        return plateau.isPositionInPlateau(positionAndOrientation);
    }

}

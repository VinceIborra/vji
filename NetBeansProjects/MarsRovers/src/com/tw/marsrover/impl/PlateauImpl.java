package com.tw.marsrover.impl;

import java.util.*;
import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class PlateauImpl implements Plateau {

    int x = -1;
    int y = -1;
    Rover currentRover;
    List<Rover> rovers = new ArrayList<Rover>();
    List<Beacon> beacons = new ArrayList<Beacon>();

    public void setX(int x) {
        this.x = x;
    }

    public int getX() {
        return this.x;
    }

    public void setY(int y) {
        this.y = y;
    }

    public int getY() {
        return this.y;
    }

    public void startNewRover(Rover rover) {
        currentRover = rover;
        rovers.add(rover);
    }

    public Rover getCurrentRover() {
        return this.currentRover;
    }

    public List<Rover> getRovers() {
        return this.rovers;
    }

    public boolean isPositionInPlateau(PositionAndOrientation positionAndOrientation) {

        // Check that we have been initialised - can't perform the check otherwise
        if (this.getX() == -1
        ||  this.getY() == -1) {
            throw new UninitialisedPlateauException("");
        }

        if (positionAndOrientation.getX() < 0
        ||  positionAndOrientation.getX() > this.getX()
        ||  positionAndOrientation.getY() < 0
        ||  positionAndOrientation.getY() > this.getY()) {
            return false;
        }

        return true;
    }

    public void assertValidPositionAndOrientation(PositionAndOrientation positionAndOrientation) {

        // Check that we have been initialised - can't perform the check otherwise
        if (this.getX() == -1
        ||  this.getY() == -1) {
            throw new UninitialisedPlateauException("");
        }

        if (positionAndOrientation.getX() < 0
        ||  positionAndOrientation.getX() > this.getX()
        ||  positionAndOrientation.getY() < 0
        ||  positionAndOrientation.getY() > this.getY()) {
            throw new InvalidPositionOrOrientationException("");
        }
    }

    public Beacon findBeaconAt(int x, int y) {
        for (Beacon beacon : beacons) {
            if (beacon.getPositionAndOrientation().getX() == x
            &&  beacon.getPositionAndOrientation().getY() == y) {
                return beacon;
            }
        }
        return null;
    }

    public void place(Rover rover) {
        rovers.add(rover);
    }

    public void place(Beacon beacon) {
        beacons.add(beacon);
    }


}

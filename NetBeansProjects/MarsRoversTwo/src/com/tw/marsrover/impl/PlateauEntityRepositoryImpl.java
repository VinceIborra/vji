package com.tw.marsrover.impl;

import java.util.*;
import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class PlateauEntityRepositoryImpl implements PlateauEntityRepository {

    Rover currentRover;
    List<Rover> rovers;
    List<Beacon> beacons = new ArrayList<Beacon>();

    public void startNewRover(Rover rover) {
        this.currentRover = rover;
        if (this.rovers == null) {
            this.rovers = new ArrayList<Rover>();
        }
        this.rovers.add(rover);
    }

    public Rover getCurrentRover() {
        return this.currentRover;
    }

    public List<Rover> getRovers() {
        if (this.rovers == null) {
            this.rovers = new ArrayList<Rover>();
        }
        return this.rovers;
    }

    public void place(Beacon beacon) {
        beacons.add(beacon);
    }

    public Rover findRoverByName(String name) {

        // If no rover specified -> return the current one
        if (name == null) {
            return this.getCurrentRover();
        }

        // Otherwise, look for it
        for (Rover rover : this.getRovers()) {
            if (rover.getName().equals(name)) {
                return rover;
            }
        }

        // Null indicates rover not found
        return null;
    }
    
    public Rover findRoverByCoords(int x, int y) {
        for (Rover rover : this.getRovers()) {
            if (rover.getPositionAndOrientation().getX() == x
            &&  rover.getPositionAndOrientation().getY() == y) {
                return rover;
            }
        }
        return null;
    }

    public Beacon findBeaconByCoords(int x, int y) {
        for (Beacon beacon : beacons) {
            if (beacon.getPositionAndOrientation().getX() == x
            &&  beacon.getPositionAndOrientation().getY() == y) {
                return beacon;
            }
        }
        return null;
    }
}

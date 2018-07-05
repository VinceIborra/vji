package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class AsciiArtPlateauAndRoversRendererImpl implements PlateauAndRoversRenderer {

    Plateau plateau;
    PlateauEntityRepository repository;
    
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

    public void render() {
        renderHorizontalBoundary();
        for (int y = this.getPlateau().getY(); y >= 0; y--) {
            renderLeftVerticalBoundary();
            for (int x = 0; x <= this.getPlateau().getX(); x++) {
                Beacon beacon = getRoverRepository().findBeaconByCoords(x, y);
                Rover rover = getRoverRepository().findRoverByCoords(x, y);
                if (beacon == null && rover == null)
                    System.out.print(" ");
                else if (beacon != null && rover != null)
                    renderBeaconAndRover(beacon, rover);
                else if (beacon != null)
                    renderBeacon(beacon);
                else
                    renderRover(rover);
            }
            renderRightVerticalBoundary();
        }
        renderHorizontalBoundary();
        renderDeadRovers();
    }

    private void renderHorizontalBoundary() {
        System.out.print("+");
        for (int x = 0; x <= this.getPlateau().getX(); x++) {
            System.out.print("-");
        }
        System.out.println("+");
    }

    private void renderLeftVerticalBoundary() {
        System.out.print("|");
    }
    private void renderRightVerticalBoundary() {
        System.out.println("|");
    }
    private void renderBeacon(Beacon beacon) {
        System.out.print("x");
    }
    private void renderRover(Rover rover) {
        if (rover == null) {
            System.out.print(" ");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.North) {
            System.out.print("^");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.South) {
            System.out.print("v");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.West) {
            System.out.print("<");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.East) {
            System.out.print(">");
        }
    }
    private void renderBeaconAndRover(Beacon beacon, Rover rover) {
        if (rover.getPositionAndOrientation().getOrientation() == Orientation.North) {
            System.out.print("A");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.South) {
            System.out.print("V");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.West) {
            System.out.print("{");
        }
        else if (rover.getPositionAndOrientation().getOrientation() == Orientation.East) {
            System.out.print("}");
        }
    }

    private void renderDeadRovers() {
        for (Rover rover : this.getRoverRepository().getRovers()) {
            if (!plateau.isPositionInPlateau(rover.getPositionAndOrientation().getX(),rover.getPositionAndOrientation().getY())) {
                if (rover.getName() != null) {
                    System.out.print(rover.getName() + " ");
                }
                System.out.print(
                    rover.getPositionAndOrientation().getX() + " " +
                    rover.getPositionAndOrientation().getY() + " " +
                    rover.getPositionAndOrientation().getOrientation() + " " +
                    "RIP"
                );
            }
        }
    }

}

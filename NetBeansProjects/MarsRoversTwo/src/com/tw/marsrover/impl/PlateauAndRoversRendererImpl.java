package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class PlateauAndRoversRendererImpl implements PlateauAndRoversRenderer {

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
        for (Rover rover : this.getRoverRepository().getRovers()) {
            System.out.print(
                rover.getPositionAndOrientation().getX() + " " +
                rover.getPositionAndOrientation().getY() + " " +
                rover.getPositionAndOrientation().getOrientation()
            );
            if (!plateau.isPositionInPlateau(rover.getPositionAndOrientation().getX(),rover.getPositionAndOrientation().getY())) {
                System.out.println(" RIP");
            }
            else {
                System.out.println("");
            }
        }
    }

}

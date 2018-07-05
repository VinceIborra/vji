package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class PlateauRendererImpl implements PlateauRenderer {

    Plateau plateau;
    
    public void setPlateau(Plateau plateau) {
        this.plateau = plateau;
    }

    public Plateau getPlateau() {
        return this.plateau;
    }

    public void render() {
        for (Rover rover : this.getPlateau().getRovers()) {
            System.out.println(
                rover.getPositionAndOrientation().getX() + " " +
                rover.getPositionAndOrientation().getY() + " " +
                rover.getPositionAndOrientation().getOrientation()
            );
        }
    }

}

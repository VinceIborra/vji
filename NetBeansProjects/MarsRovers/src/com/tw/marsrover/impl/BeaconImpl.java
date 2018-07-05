/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.tw.marsrover.impl;

//import com.tw.marsrover.*;

import com.tw.marsrover.Beacon;
import com.tw.marsrover.Plateau;
import com.tw.marsrover.PositionAndOrientation;

/**
 *
 * @author vji
 */
public class BeaconImpl implements Beacon {

    private Plateau plateau;
    private PositionAndOrientation positionAndOrientation;

    public void setPositionAndOrientation(PositionAndOrientation positionAndOrientation) {
        this.positionAndOrientation = positionAndOrientation;
    }

    public void setPlateau(Plateau plateau) {
        this.plateau = plateau;
    }

    public Plateau getPlateau() {
        return plateau;
    }

    public PositionAndOrientation getPositionAndOrientation() {
        return positionAndOrientation;
    }
}

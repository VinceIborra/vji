/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.tw.marsrover.impl;

import com.tw.marsrover.Beacon;
import com.tw.marsrover.PositionAndOrientation;

/**
 *
 * @author vji
 */
public class BeaconImpl implements Beacon {

    PositionAndOrientation positionAndOrientation;

    public void setPositionAndOrientation(PositionAndOrientation positionAndOrientation) {
        this.positionAndOrientation = positionAndOrientation;
    }

    public PositionAndOrientation getPositionAndOrientation() {
        return this.positionAndOrientation;
    }
}

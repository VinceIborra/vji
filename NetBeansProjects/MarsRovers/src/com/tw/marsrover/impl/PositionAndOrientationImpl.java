package com.tw.marsrover.impl;

import com.tw.marsrover.Orientation;
import com.tw.marsrover.PositionAndOrientation;

/**
 *
 * @author vji
 */
public class PositionAndOrientationImpl implements PositionAndOrientation {

    private int x;
    private int y;
    private Orientation orientation;

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

    public void setOrientation(Orientation orientation) {
        this.orientation = orientation;
    }
    public Orientation getOrientation() {
        return this.orientation;
    }

    @Override
    public boolean equals(Object obj) {

        if (obj == null) {
            return false;
        }

        if (! (obj instanceof PositionAndOrientation)) {
            return false;
        }

        PositionAndOrientation positionAndOrientation = (PositionAndOrientation) obj;
        if (positionAndOrientation.getX() != this.getX()
        ||  positionAndOrientation.getY() != this.getY()
        ||  positionAndOrientation.getOrientation() != this.getOrientation()) {
            return false;
        }

        return true;
    }

}

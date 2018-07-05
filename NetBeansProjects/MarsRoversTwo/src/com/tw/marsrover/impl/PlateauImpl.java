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

    public boolean isPositionInPlateau(int x, int y) {

        // Check that we have been initialised - can't perform the check otherwise
        if (this.getX() == -1
        ||  this.getY() == -1) {
            throw new UninitialisedPlateauException("");
        }

        if (x < 0
        ||  x > this.getX()
        ||  y < 0
        ||  y > this.getY()) {
            return false;
        }

        return true;
    }
}

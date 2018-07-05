package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class PlateauChangeCommandImpl implements PlateauChangeCommand {

    private int x;
    private int y;

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

    @Override
    public boolean equals(Object obj) {

        if (obj == null) {
            return false;
        }

        if (! (obj instanceof PlateauChangeCommand)) {
            return false;
        }

        PlateauChangeCommand command = (PlateauChangeCommand) obj;
        if (command.getX() != this.getX()
        ||  command.getY() != this.getY()) {
            return false;
        }

        return true;
    }

    public void process(RoverController controller) {
        controller.processCommand(this);
    }
}

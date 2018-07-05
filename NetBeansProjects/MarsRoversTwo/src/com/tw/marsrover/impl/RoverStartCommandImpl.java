package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverStartCommandImpl extends RoverChangeCommandImpl implements RoverStartCommand {

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

        if (! (obj instanceof RoverStartCommand)) {
            return false;
        }

        RoverStartCommand command = (RoverStartCommand) obj;
        if ((command.getName() != null && !command.getName().equals(this.getName()))
        ||  (this.getName() != null && !this.getName().equals(command.getName()))) {
            return false;
        }
        if (command.getX() != this.getX()
        ||  command.getY() != this.getY()
        ||  command.getOrientation() != this.getOrientation()) {
            return false;
        }

        return true;
    }
    
    public void process(RoverController controller) {
        controller.processCommand(this);
    }
}

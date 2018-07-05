package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverTurnRightCommandImpl extends RoverChangeCommandImpl implements RoverTurnRightCommand {

    @Override
    public boolean equals(Object obj) {

        if (obj == null) {
            return false;
        }

        if (! (obj instanceof RoverTurnRightCommand)) {
            return false;
        }

        return true;
    }
    
    public void process(RoverController controller) {
        controller.processCommand(this);
    }
}

package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverTurnRightCommandImpl implements RoverTurnRightCommand {
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

}

package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverMoveCommandImpl implements RoverMoveCommand {
    @Override
    public boolean equals(Object obj) {

        if (obj == null) {
            return false;
        }

        if (! (obj instanceof RoverMoveCommand)) {
            return false;
        }

        return true;
    }

}

package com.tw.marsrover.impl;

import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverTurnLeftCommandImpl implements RoverTurnLeftCommand {

    @Override
    public boolean equals(Object obj) {

        if (obj == null) {
            return false;
        }

        if (! (obj instanceof RoverTurnLeftCommand)) {
            return false;
        }

        return true;
    }
}

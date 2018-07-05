package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface RoverStartCommand extends Command {
    public int getX();
    public int getY();
    public Orientation getOrientation();
}

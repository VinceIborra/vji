package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface RoverStartCommand extends RoverChangeCommand {
    public int getX();
    public int getY();
    public Orientation getOrientation();
}

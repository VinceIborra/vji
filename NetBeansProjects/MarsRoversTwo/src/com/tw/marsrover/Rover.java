package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface Rover {

    String getName();
    PositionAndOrientation getPositionAndOrientation();

    void turnLeft();
    void turnRight();
    void move();
}

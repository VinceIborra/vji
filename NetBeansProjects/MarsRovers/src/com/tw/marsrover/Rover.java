package com.tw.marsrover;

/**
 *
 * @author vji
 */
public interface Rover {

    PositionAndOrientation getPositionAndOrientation();

    void turnLeft();
    void turnRight();
    void move();

    boolean isRoverInPlateau();

}

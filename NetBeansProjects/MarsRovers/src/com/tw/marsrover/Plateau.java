package com.tw.marsrover;

import java.util.*;

/**
 *
 * @author vji
 */
public interface Plateau {

  public void setX(int x);
  public int getX();
  public void setY(int y);
  public int getY();

  public void startNewRover(Rover rover);
  public Rover getCurrentRover();

  public void place(Beacon beacon);
  public void place(Rover rover);

  public List<Rover> getRovers();

  public boolean isPositionInPlateau(PositionAndOrientation positionAndOrientation);
  public void assertValidPositionAndOrientation(PositionAndOrientation positionAndOrientation);

  public Beacon findBeaconAt(int x, int y);
}

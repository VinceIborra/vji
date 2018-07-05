package com.tw.marsrover;

import java.util.*;

/**
 *
 * @author vji
 */
public interface PlateauEntityRepository {

  void startNewRover(Rover rover);
  Rover getCurrentRover();
  List<Rover> getRovers();

  void place(Beacon beacon);

  Rover findRoverByName(String name);
  Rover findRoverByCoords(int x, int y);

  Beacon findBeaconByCoords(int x, int y);
}

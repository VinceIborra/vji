package com.tw.marsrover;

import java.util.*;

/**
 *
 * @author vji
 */
public interface Plateau {

  void setX(int x);
  int getX();
  void setY(int y);
  int getY();

  boolean isPositionInPlateau(int x, int y);
}

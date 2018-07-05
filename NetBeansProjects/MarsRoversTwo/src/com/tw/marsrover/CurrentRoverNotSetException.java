package com.tw.marsrover;

/**
 *
 * @author vji
 */
public class CurrentRoverNotSetException extends RuntimeException {
  public CurrentRoverNotSetException(String message) {
      super(message);
  }
}

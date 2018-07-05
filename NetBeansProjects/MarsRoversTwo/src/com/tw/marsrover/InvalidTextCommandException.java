package com.tw.marsrover;

/**
 *
 * @author vji
 */
public class InvalidTextCommandException extends RuntimeException {
  public InvalidTextCommandException(String message) {
      super(message);
  }
}

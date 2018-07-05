package com.tw.marsrover;

import java.util.*;

/**
 *
 * @author vji
 */
public interface CommandParser {
    public List<Command> parseTextLine(String line);
}

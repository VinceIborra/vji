package com.tw.marsrover.impl;

import java.util.*;
import java.util.regex.*;
import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class NamedRoverCommandParserImpl implements CommandParser {

    Factory factory;

    public void setFactory(Factory factory) {
        this.factory = factory;
    }

    public Factory getFactory() {
        return this.factory;
    }

    public List<Command> parseTextLine(String line) {

        // Start up a list of commands
        ArrayList<Command> commands = new ArrayList<Command>();

        // And their corresponding matchers
        Matcher plateauDimensionMatcher = Pattern.compile("(\\d+) (\\d+)").matcher(line);
        Matcher roverStartMatcher = Pattern.compile("(\\w+) (\\d+) (\\d+) ([NSEW])").matcher(line);
        Matcher roverMoveMatcher = Pattern.compile("(\\w+) ([LRM]+)").matcher(line);

        if (plateauDimensionMatcher.matches()) {
            commands.add(
                this.getFactory().newPlateauChangeCommand(
                    Integer.parseInt(plateauDimensionMatcher.group(1)),
                    Integer.parseInt(plateauDimensionMatcher.group(2))
                )
            );
        }
        else if (roverStartMatcher.matches()) {
            commands.add(
                this.getFactory().newRoverStartCommand(
                    roverStartMatcher.group(1),
                    Integer.parseInt(roverStartMatcher.group(2)),
                    Integer.parseInt(roverStartMatcher.group(3)),
                    Orientation.fromString(roverStartMatcher.group(4))
                )
            );
        }
        else if (roverMoveMatcher.matches()) {
            String name = roverMoveMatcher.group(1);
            String [] strings = roverMoveMatcher.group(2).split("");
            for (int i=1; i < strings.length; i++) {
                commands.add(
                    this.getFactory().newRoverChangeCommand(name, RoverChangeEnum.fromString(strings[i]))
                );
            }
        }
        else {
            throw new InvalidTextCommandException("Invalid text command : " + line);
        }

        return commands;
    }
}

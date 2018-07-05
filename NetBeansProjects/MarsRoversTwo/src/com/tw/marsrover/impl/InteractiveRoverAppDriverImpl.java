package com.tw.marsrover.impl;

import java.util.*;
import java.io.*;
import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class InteractiveRoverAppDriverImpl extends RoverAppDriverImpl implements RoverAppDriver {

    public void run() {

        // Print help commands
        System.out.println("Commands:");
        System.out.println("  <x-coord> <y-coord>                            # Plateau Change Command");
        System.out.println("  <name> <x-coord> <y-coord> <orientation>       # Start new rover");
        System.out.println("  <name> <MLR>                                   # Change rover (move, left, right)");
        System.out.println("  exit");
        System.out.print("\n");

        // Process User Commands until we're done
        Scanner in = new Scanner(System.in);
        boolean done = false;
        String message = "";
        while (!done) {

            try {
                
                // Show plateau and rovers
                renderer.render();
                
                // Prompt user, and get next command
                System.out.println("\n");
                System.out.print("Enter next command: ");
                String strLine = in.nextLine();
                
                // Parse user command(s)
                if (strLine.equals("exit")) {
                    done = true;
                    continue;
                }
                List<Command> commands;
                commands = parser.parseTextLine(strLine);

                // Execute all commands
                for (Command command : commands )   {
                    try {
                        controller.processCommand(command);
                    }
                    catch (InvalidPositionOrOrientationException roverChangeException) {
                        System.err.println("There was an invalid change to the rover - command ignored.");
                    }
                }
            }
            catch (Exception e){
                System.err.println("Error: " + e.getMessage());
                e.printStackTrace();
            }
        }
    }

}
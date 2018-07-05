package com.tw.marsrover.impl;

import java.util.*;
import java.io.*;
import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class FileRoverAppDriverImpl extends RoverAppDriverImpl implements RoverAppDriver {

    public void run() {

        try{
            FileInputStream inStream = new FileInputStream(args[0]);
            DataInputStream in = new DataInputStream(inStream);
            BufferedReader br = new BufferedReader(new InputStreamReader(in));
            String strLine;

            List<Command> commands;
            while ((strLine = br.readLine()) != null)   {

                // Get the commands for the next line
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

            // Render plateau
            renderer.render();

            in.close();
        }
        catch (Exception e){
            System.err.println("Error: " + e.getMessage());
            e.printStackTrace();
        }
    }

}
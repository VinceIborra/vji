package com.tw.marsrover;

import java.util.*;
import java.io.*;
import com.tw.marsrover.impl.FactoryImpl;

/**
 *
 * @author vji
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        Factory factory = new FactoryImpl();
        CommandParser commandParser = factory.newCommandParser(factory);
        Plateau plateau = factory.newPlateau();
        RoverController roverController = factory.newRoverController(factory, plateau);
        PlateauRenderer plateauRenderer = factory.newPlateauRenderer(plateau);

        try{
            FileInputStream inStream = new FileInputStream(args[0]);
            DataInputStream in = new DataInputStream(inStream);
            BufferedReader br = new BufferedReader(new InputStreamReader(in));
            String strLine;

            List<Command> commands;
            while ((strLine = br.readLine()) != null)   {

                // Get the commands for the next line
                commands = commandParser.parseTextLine(strLine);

                // Execute all commands
                for (Command command : commands )   {
                    try {
                        roverController.processCommand(command);
                    }
                    catch (InvalidPositionOrOrientationException roverChangeException) {
                        System.err.println("There was an invalid change to the rover - command ignored.");
                    }
                }
            }

            // Render plateau
            plateauRenderer.render();

            in.close();
        }
        catch (Exception e){
            System.err.println("Error: " + e.getMessage());
            e.printStackTrace();
        }
    }
}

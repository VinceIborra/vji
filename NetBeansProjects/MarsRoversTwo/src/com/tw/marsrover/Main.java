package com.tw.marsrover;

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

        // File interaction mode
//        Factory factory = new FactoryImpl();
//        CommandParser commandParser = factory.newAnonymousRoverCommandParser(factory);
//        Plateau plateau = factory.newPlateau();
//        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
//        RoverLogger logger = factory.newRoverLogger("rover.log");
//        RoverController roverController = factory.newRoverController(factory, plateau, repository, logger);
//        PlateauAndRoversRenderer renderer = factory.newPlateauAndRoversRenderer(plateau, repository);
//        RoverAppDriver driver = factory.newFileRoverAppDriver(args, commandParser, roverController, renderer);
//        driver.run();

        // User interaction mode
        Factory factory = new FactoryImpl();
        CommandParser commandParser = factory.newNamedRoverCommandParser(factory);
        Plateau plateau = factory.newPlateau();
        PlateauEntityRepository repository = factory.newPlateauEntityRepository();
        RoverLogger logger = factory.newRoverLogger("rover.log");
        RoverController roverController = factory.newRoverController(factory, plateau, repository, logger);
        PlateauAndRoversRenderer renderer = factory.newAsciiArtPlateauAndRoversRenderer(plateau, repository);
        RoverAppDriver driver = factory.newInteractiveRoverAppDriver(args, commandParser, roverController, renderer);
        driver.run();
    }
}

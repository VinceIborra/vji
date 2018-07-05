package vji.app.chess;
import org.springframework.context.*;
import org.springframework.context.support.*;
import vji.mvc.*;

/**
 *
 * @author vji
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ApplicationContext context = new ClassPathXmlApplicationContext(new String[] {"chess.xml"});
        Driver driver = (Driver) context.getBean("driver");
        driver.run();
    }
}

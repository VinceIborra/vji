package vji.chess.mvc;

import java.util.*;
import vji.mvc.*;

/**
 *
 * @author vji
 */
public class InputImpl implements Input {

    private Scanner _scanner;

    private void setScanner(Scanner scanner) { _scanner = scanner; }
    private Scanner getScanner() { return _scanner; }

    private InputImpl() {
        setScanner(new Scanner(System.in));
    }

    public String collect() {
        return getScanner().nextLine();
    }
}

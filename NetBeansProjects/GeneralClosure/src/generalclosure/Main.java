/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package generalclosure;

import java.util.*;

/**
 *
 * @author vji
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        String msg = "Hello, world!\n";
        HashMap<String, Object> context = new HashMap<String, Object>();
        context.put("message", msg);

        Closure closure = new Closure() {
            public void yield(Map<String, Object> context) {
                String msg = (String) context.get("message");
                System.out.println(msg);
            }
        };
        closure.yield(context);
    }
}

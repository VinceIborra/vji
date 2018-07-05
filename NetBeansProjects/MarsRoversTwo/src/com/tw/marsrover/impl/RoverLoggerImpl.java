/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.tw.marsrover.impl;

import java.io.*;
import com.tw.marsrover.*;

/**
 *
 * @author vji
 */
public class RoverLoggerImpl implements RoverLogger {

    String fileName;

    public void setFileName(String fileName) { this.fileName = fileName; }
    public String getFileName() { return this.fileName; }

    public void log(String msg) {

       try {
           BufferedWriter out = new BufferedWriter(new FileWriter(fileName, true));
           out.write(msg + "\n");
           out.close();
       } catch (IOException e) {
       }
    }
}

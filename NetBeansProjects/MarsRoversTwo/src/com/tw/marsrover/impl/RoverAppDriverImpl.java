/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.tw.marsrover.impl;

import com.tw.marsrover.CommandParser;
import com.tw.marsrover.PlateauAndRoversRenderer;
import com.tw.marsrover.RoverController;

/**
 *
 * @author vji
 */
abstract public class RoverAppDriverImpl {

    public RoverAppDriverImpl() {
    }
    String[] args;
    RoverController controller;
    CommandParser parser;
    PlateauAndRoversRenderer renderer;

    public String[] getArgs() {
        return this.args;
    }

    public RoverController getController() {
        return this.controller;
    }

    public CommandParser getParser() {
        return this.parser;
    }

    public PlateauAndRoversRenderer getRenderer() {
        return this.renderer;
    }

    public void setArgs(String[] args) {
        this.args = args;
    }

    public void setController(RoverController controller) {
        this.controller = controller;
    }

    public void setParser(CommandParser parser) {
        this.parser = parser;
    }

    public void setRenderer(PlateauAndRoversRenderer renderer) {
        this.renderer = renderer;
    }

}

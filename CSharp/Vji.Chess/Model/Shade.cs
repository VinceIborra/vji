using System;
using System.Collections.Generic;

namespace Vji.Chess.Model {

    public class Shade {

        public string Value { get; private set; }
        
        private Shade(string value) {
            this.Value = value;
        }
        
        public static Shade Light = new Shade("Light");
        public static Shade Dark = new Shade("Dark");
        
        public static IList<Shade> Items = new List<Shade>() {
            Shade.Light,
            Shade.Dark
        };        
    }
}
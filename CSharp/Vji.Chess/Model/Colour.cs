using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public class Colour {

        public string Value { get; private set; }

        private Colour(string value) {
            Value = value;
        }

        public static Colour Black = new Colour("Black");
        public static Colour White = new Colour("White");
    }
}

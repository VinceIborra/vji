using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public class DriverState {
        private string Value { set; get; }
        private DriverState(string value) {
            Value = value;
        }
        public static DriverState Starting = new DriverState("Starting");
        public static DriverState Running = new DriverState("Running");
        public static DriverState Finishing = new DriverState("Finishing");
    }
}

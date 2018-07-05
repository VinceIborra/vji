using System;

namespace Vji.Standard.Mvc {

    public class ConsoleLineSourceImpl : LineSource {
        
        public string NextLine() {
            return System.Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;

namespace Vji.Standard.Mvc {
    public class CommandLineInputImpl : Input {

        public Factory MvcFactory { set; get; }
        public LineSource LineSource { set; get; }
        public Parser Parser { set; get; }

        public Command Next() {
            string line = this.LineSource.NextLine();
            Command command = this.Parser.Parse(line);
            return command;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Bootstrap;

namespace Vji.App.CommandLineChess {
    public class ProgramClass : Program {

        public Bootstrapper Bootstrapper { set; get; }
        public Runner Runner { set; get; }

        public void Run() {
            Bootstrapper.Bootstrap();
            Runner.Run();
        }
    }
}

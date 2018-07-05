using System;
using Vji.Bootstrap;

namespace Vji.App.CommandLineChess {
    public interface Program {

        Bootstrapper Bootstrapper { get; set; }

        Runner Runner { get; set; }

        void Run();
        
    }
}

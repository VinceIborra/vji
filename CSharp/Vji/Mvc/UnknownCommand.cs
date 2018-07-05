using System;

namespace Vji.Mvc {

    public interface UnknownCommand : Command {
        string Comment { get; }
    }
}

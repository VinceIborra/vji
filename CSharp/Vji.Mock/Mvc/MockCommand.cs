using System;
using Vji.Mvc;

namespace Vji.Mock.Mvc {

    public interface MockCommand : Command {
        
        string Message { get; }
    }
}

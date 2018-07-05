using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Microsoft.Excel {
    public interface Cell {
        string Text { get; }
        string Comment { get; }
    }
}

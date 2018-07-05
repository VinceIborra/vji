using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Microsoft.Excel {
    public interface Range {
        int RowCount { get; }
        int ColCount { get; }

        Cell this [int row, int col] { get; }
    }
}

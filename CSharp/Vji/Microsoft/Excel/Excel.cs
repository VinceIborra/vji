using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Microsoft.Excel {
    public interface Excel : IDisposable {

        string FilePath { get; }

        void Start();
        void Stop();

        void Open();
        void Close();

        void Select(string sheetName);

        Range UsedRange();
    }
}

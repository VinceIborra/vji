using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public interface Location {
        
        Shade Shade { get; }
        Piece Piece { set; get; }

    }
}

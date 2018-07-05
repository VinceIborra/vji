using System;

namespace Vji.Chess.Model {

    public interface Move {
        Type Type { get; }
        Rank FromRank { get; }
        File FromFile  { get; }
        Rank ToRank { get; }
        File ToFile { get; }
        bool Capture { get; }
    }
}

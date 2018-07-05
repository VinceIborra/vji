using System;

namespace Vji.Chess.Model {

    public class MoveImpl : Move {
        public Type Type { set; get; }
        public Rank FromRank { set; get; }
        public File FromFile  { set; get; }
        public Rank ToRank { set; get; }
        public File ToFile { set; get; }
        public bool Capture { set; get; }
    }
}

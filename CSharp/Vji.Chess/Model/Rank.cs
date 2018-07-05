using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public class Rank {

        public int Idx { get; private set; }
        public string Value { get; private set; }

        private Rank(int idx, string value) {
            Idx = idx;
            Value = value;
        }

        public static Rank FromString(String str) {
            String capitalisedStr = str.ToUpper();
            foreach (Rank rank in Rank.Items) {
                if (rank.Value == capitalisedStr) {
                    return rank;
                }
            }
            return null;
        }

        public static Rank Rank1 = new Rank(7, "1");
        public static Rank Rank2 = new Rank(6, "2");
        public static Rank Rank3 = new Rank(5, "3");
        public static Rank Rank4 = new Rank(4, "4");
        public static Rank Rank5 = new Rank(3, "5");
        public static Rank Rank6 = new Rank(2, "6");
        public static Rank Rank7 = new Rank(1, "7");
        public static Rank Rank8 = new Rank(0, "8");

        public static IList<Rank> Items = new List<Rank>() {
            Rank.Rank1,
            Rank.Rank2,
            Rank.Rank3,
            Rank.Rank4,
            Rank.Rank5,
            Rank.Rank6,
            Rank.Rank7,
            Rank.Rank8
        };
    }
}

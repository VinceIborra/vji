using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public class File {

        public int Idx { get; private set; }
        public string Value { get; private set; }

        private File(int idx, string value) {
            Idx = idx;
            Value = value;
        }

        public static File FromString(String str) {
            String capitalisedStr = str.ToUpper();
            foreach (File file in File.Items) {
                if (file.Value == capitalisedStr) {
                    return file;
                }
            }
            return null;
        }

        public static File FileA = new File(0, "A");
        public static File FileB = new File(1, "B");
        public static File FileC = new File(2, "C");
        public static File FileD = new File(3, "D");
        public static File FileE = new File(4, "E");
        public static File FileF = new File(5, "F");
        public static File FileG = new File(6, "G");
        public static File FileH = new File(7 ,"H");

        public static IList<File> Items = new List<File>() {
            File.FileA,
            File.FileB,
            File.FileC,
            File.FileD,
            File.FileE,
            File.FileF,
            File.FileG,
            File.FileH
        };
    }
}

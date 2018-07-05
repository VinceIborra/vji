using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Microsoft.Excel {
    class RangeImpl {
    }
}
//using Microsoft.Office.Interop.Excel;
//using Vji.Util;

//namespace Vji.App.Excel {
//    public class RangeClass : ComWrapperClass<Microsoft.Office.Interop.Excel.Range>, Range, ComWrapper<Microsoft.Office.Interop.Excel.Range> {

//        public int RowCount {
//            get {
//                return Reference.Rows.Count;
//            }
//        }
//        public int ColCount {
//            get {
//                return Reference.Columns.Count;
//            }
//        }

//        public Cell this [int row, int col] {
//            get {
//                var cell = new CellClass();
//                var cellRange = Reference[row+1, col+1] as Microsoft.Office.Interop.Excel.Range;
//                cell.Text = cellRange.Text as string;
//                if (cell.Comment != null) {
//                    cell.Comment = cellRange.Comment.ToString();
//                }
//                return cell;
//            }
//        }
//    }
//}

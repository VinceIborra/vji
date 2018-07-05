using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Microsoft.Excel {
    public class ExcelImpl {
    }
}
//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
//using log4net;
//using Vji.Util;

//namespace Vji.App.Excel {
//    public class ExcelClass : Excel {

//        public ILog Logger { set; get; }

//        public string FilePath { set; get; }

//        private Application Application { set; get; }
//        private Workbooks Workbooks { set; get; }
//        private Sheets Sheets { set; get; }
        
//        private Workbook CurrentWorkbook { set; get; }
//        private Worksheet CurrentSheet { set; get; }

//        public void Start() {
//            Application = new ApplicationClass();
//        }
//        public void Stop() {
//            if (Application == null) {
//                return;
//            }
//            Application.Quit();
//        }

//        public void Open() {

//            // Get the workbooks
//            Workbooks = Application.Workbooks;

//            //  And open the relevant one
//            CurrentWorkbook = Workbooks.Open(
//                FilePath, 
//                0, 
//                true, 
//                5, 
//                string.Empty, 
//                string.Empty, 
//                true, 
//                XlPlatform.xlWindows, 
//                "\t", 
//                false, 
//                false, 
//                0, 
//                true, 
//                1, 
//                0
//            );
//        }

//        public void Close() {
//            if (CurrentWorkbook == null) {
//                return;
//            }
//            CurrentWorkbook.Close(true, null, null);
//            CurrentWorkbook = null;
//        }

//        public void Select(string sheetName) {
//            Sheets = CurrentWorkbook.Worksheets;
//            CurrentSheet = Sheets.get_Item(sheetName) as Worksheet;
//        }

//        public Range UsedRange() {

//            // Get the full range
//            Microsoft.Office.Interop.Excel.Range comRange = CurrentSheet.UsedRange;

//            // Return a wrapper for it
//            RangeClass range = new RangeClass();
//            range.Reference = comRange;
//            return range;
//        }

//        private void Dispose(object comObject) {

//            // Nothing to clean up, if we don't have a reference to a COM object
//            if (comObject == null) {
//                return;
//            }

//            // Catch any errors while the resource is released
//            try {
//                Marshal.FinalReleaseComObject(comObject);
//            }

//            // And if they occur, tell somebody about it
//            catch (Exception exception) {
//                Logger.Warn("Exception occurred while releasing object : " + comObject.GetType().FullName);
//                Logger.Warn(exception.Message);
//                Logger.Warn(exception.StackTrace);
//            }
//        }

//        public void Dispose() {

//            // Close any files
//            Close();

//            // Stop Excel
//            Stop();

//            // And dispose of any COM objects
//            if (CurrentSheet != null) {
//                Dispose(CurrentSheet);
//                CurrentSheet = null;
//            }
//            if (CurrentWorkbook != null) {
//                Dispose(CurrentWorkbook);
//                CurrentWorkbook = null;
//            }
//            if (Sheets != null) {
//                Dispose(Sheets);
//                Sheets = null;
//            }
//            if (Workbooks != null) {
//                Dispose(Workbooks);
//                Workbooks = null;
//            }
//            if (Application != null) {
//                Dispose(Application);
//                Application = null;
//            }
//        }

//        ~ExcelClass() {
//            Dispose();
//        }
//    }
//}

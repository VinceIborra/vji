using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Standard.Directories {
    class Utility {
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using Common.Exception;

//// TODO: VJI: Merge parts of this into Vji.Test.TestClass
//// TODO: VJI: Merge parts of this into Vji.Util.DriverClass
//namespace Common {
//    /// <summary>
//    /// Various utilities for common operations.
//    /// </summary>
//    static public class Utility {
//        /// <summary>
//        /// Resolves the full file path from a relative one (if applicable).
//        /// </summary>
//        /// <param name="relativePath">The relative path.</param>
//        /// <returns></returns>
//        public static string ResolveRelativePath(string relativePath)
//        {
//            const string BINDIRECTORY = @"\bin\";
//            const string TESTDIRECTORY = @"\TestResults\";

//            string executablePath = Environment.CurrentDirectory;
//            int binDirectory = executablePath.LastIndexOf(BINDIRECTORY);
//            if (binDirectory != -1) {
//                // Remove bin directory if we in debugging mode.
//                executablePath = executablePath.Substring(0, binDirectory);
//            }

//            int testDirectory = executablePath.LastIndexOf(TESTDIRECTORY);
//            if (testDirectory != -1) {
//                // Remove up to (but not including) test directory if we are running tests.
//                executablePath = executablePath.Substring(0, testDirectory + TESTDIRECTORY.Length - 1);
//            }

//            return ResolveRelativePath(relativePath, executablePath);
//        }

//        /// <summary>
//        /// Resolves the full file path from a relative one (if applicable).
//        /// </summary>
//        /// <param name="relativePath">The relative path.</param>
//        /// <param name="basePath">The base path.</param>
//        /// <returns></returns>
//        public static string ResolveRelativePath(string relativePath, string basePath)
//        {
//            if (Path.IsPathRooted(relativePath)){
//                // Not a relative path.
//                return relativePath;
//            }

//            string[] baseParts = basePath.Split(Path.DirectorySeparatorChar);
//            string[] relativeParts = relativePath.Split(Path.DirectorySeparatorChar);
            
//            int relativeIndicators = 0;
//            while (relativeParts[relativeIndicators] == "..") {
//                relativeIndicators++;
//            }

//            if (relativeIndicators > baseParts.Length) {
//                // We can't exist as the relative parts are greater than what is left in the base.
//                throw new CommonException(CommonError.RelativePathInvalid, relativePath, basePath);
//            }

//            string relativeBase = string.Join(Path.DirectorySeparatorChar.ToString(), baseParts, 0 , baseParts.Length - relativeIndicators);
//            string relativeRest = string.Join(Path.DirectorySeparatorChar.ToString(), relativeParts, relativeIndicators, relativeParts.Length - relativeIndicators);
            
//            return Path.Combine(relativeBase, relativeRest);
//        }
//    }
//}

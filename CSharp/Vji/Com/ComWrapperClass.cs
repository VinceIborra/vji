using System;
using System.Runtime.InteropServices;
using log4net;

namespace Vji.Util {

    /// <summary>
    /// COM Wrapper.  Implements the RAII pattern to ensure COM objects are safely cleaned up when they are out of scope.
    /// </summary>
    /// <typeparam name="TReference">The type of the COM reference.</typeparam>
    public class ComWrapperClass<TReference> : ComWrapper<TReference> {

        public ILog Logger { set; get; }

        /// <summary>
        /// Public Reference to COM object.
        /// </summary>
        /// <value>The handle.</value>
        public TReference Reference { get; set; }

        public ComWrapperClass() {
            Reference = default(TReference);
        }

        public void Dispose() {

            // Nothing to clean up, if we don't have a reference to a COM object
            if (Reference == null) {
                return;
            }

            // Catch any errors while the resource is released
            try {
                Marshal.FinalReleaseComObject(Reference);
                Reference = default(TReference);
            }

            // And if they occur, tell somebody about it
            catch (Exception exception) {
                Logger.Warn("Exception occurred while releasing object : " + typeof(TReference).FullName);
                Logger.Warn(exception.Message);
                Logger.Warn(exception.StackTrace);
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ComWrapper&lt;TCOMReference&gt;"/> is reclaimed by garbage collection.
        /// </summary>
        ~ComWrapperClass() {
            Dispose();
        }
    }
}

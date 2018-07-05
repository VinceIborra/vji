using System;
using System.Collections.Generic;
using Vji.Exceptions;

namespace Vji.Mvc {

    public class SafeViewImpl : View {
        
        public View UnsafeView { set; get; }
        
        public string Render(IDictionary<string, Object> model) {
            try {
                return this.UnsafeView.Render(model);
            }
            catch (InternalErrorException internalErrorException) {
                return internalErrorException.Message;
            }
            catch (Exception exception) {
                return exception.Message + exception.StackTrace;
            }
        }
    }
}

using System;

namespace Vji.Exceptions {
    public class InternalErrorException : Exception {
        
        private const string _INTERNAL_ERROR_MESSAGE
            = "An internal error has occurred.  Please contact system maintainer.";

        public InternalErrorException()
            : base(_INTERNAL_ERROR_MESSAGE) {
        }
        
        public InternalErrorException(string message) 
            : base(message + " - " + _INTERNAL_ERROR_MESSAGE) {
        }
    }
}

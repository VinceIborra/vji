using System;
using System.Collections.Generic;
using Vji.Exceptions;
using Vji.Mvc;

namespace Vji.Mock.Mvc {

    public class MockUnsafeViewImpl : View {
        
        public Exception Exception { set; get; }
        
        public string Render(IDictionary<string, Object> model) {
            throw this.Exception;
        }
        
    }
}

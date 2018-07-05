using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Log4net;
using Vji.Mvc;

namespace Vji.Mock.Mvc {
    public class MockViewResolverImpl : ViewResolver, LoggerRecipient {

        public ILog Logger { set; get; }
        public FactoryImpl MockMvcFactory { set; get; }

        public View Resolve(string viewName) {
            return MockMvcFactory.NewMockView(viewName);
        }
    }
}

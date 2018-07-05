using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Mvc;
using Vji.Log4net;

namespace Vji.Mock.Mvc {
    public class MockOutputImpl : Output, LoggerRecipient {

        public ILog Logger { set; get; }

        public ViewResolver ViewResolver { set; get; }

        public IList<string> Output { set; get; }

        public MockOutputImpl() {
            Output = new List<string>();
        }

        public void Present(ModelAndView modelAndView) {
            View view = ViewResolver.Resolve(modelAndView.ViewName);
            Output.Add(view.Render(modelAndView.Model));
            Logger.Info(modelAndView);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Log4net;
using Vji.Mvc;

namespace Vji.Mock.Mvc {
    public class MockViewImpl : View, LoggerRecipient {

        public ILog Logger { set; get; }

        public string Name { set; get; }

        public string Render(IDictionary<string, object> model) {
            string str = "{";
            bool first = true;
            foreach (string key in model.Keys) {
                str += (first)? "" : ", ";
                str += key + " => " + model[key];
                first = false;
            }
            str += "}";
            return str;
        }
    }
}

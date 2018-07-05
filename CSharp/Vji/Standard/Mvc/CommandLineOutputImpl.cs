using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;

namespace Vji.Standard.Mvc {
    public class CommandLineOutputImpl : Output {

        public ViewResolver ViewResolver { set; get; }

        private void Present(string message) {
            Console.Write(message);
        }

        public void Present(ModelAndView modelAndView) {
            View view = ViewResolver.Resolve(modelAndView.ViewName);
            string output = view.Render(modelAndView.Model);
            Present(output);
        }
    }
}

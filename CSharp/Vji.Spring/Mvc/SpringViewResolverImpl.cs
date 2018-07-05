using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Vji.Mvc;

namespace Vji.Spring.Mvc {
    public class SpringViewResolverImpl : ViewResolver, IApplicationContextAware {
        
        public IApplicationContext ApplicationContext { set; get; }
        public Vji.Mvc.Factory Factory { set; get; }
        
        private View GetSpringManagedView(string viewName) {
            return (View) ApplicationContext.GetObject(viewName);
        }
        
        private View WrapInASafeView(View unsafeView) {
            return this.Factory.NewSafeView(unsafeView);
        }

        public View Resolve(string viewName) {
            View unsafeView = this.GetSpringManagedView(viewName);
            View safeView = this.WrapInASafeView(unsafeView);
            return safeView;
        }
    }
}

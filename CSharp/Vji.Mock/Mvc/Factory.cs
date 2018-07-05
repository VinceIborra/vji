using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;

namespace Vji.Mock.Mvc {
    public interface Factory {

        Input NewMockInput();

        Output NewMockOutput(ViewResolver viewResolver);
        
        Controller NewMockController(Vji.Mvc.Factory mvcFactory);
        
        ViewResolver NewMockViewResolver();
        
        View NewMockView(string viewName);

        Command NewMockCommand(string enteredString);
    }
}

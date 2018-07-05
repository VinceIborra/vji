using System;

namespace Vji.Mock.Standard.Mvc {

    public class FactoryImpl {
        public DoitCommand NewDoitCommand() {
            return new DoitCommandImpl();
        }
    }
}

using System;
using Vji.Exceptions;
using Vji.Mvc;

namespace Vji.Mock.Standard.Mvc {
 
    public class MockParserImpl : Parser {
        
        private Vji.Mock.Standard.Mvc.FactoryImpl Factory { set; get; }
        
        public MockParserImpl() {
            this.Factory = new Vji.Mock.Standard.Mvc.FactoryImpl();
        }
        
        public Command Parse(string message) {
            switch(message) {
                case "doit": return this.Factory.NewDoitCommand();
                default: throw new InternalErrorException();
            }
        }
    }
}

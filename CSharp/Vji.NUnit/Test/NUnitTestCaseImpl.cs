using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NUnit.Framework;
using Vji.Test;

namespace Vji.NUnit.Test {
    
    [TestFixture]
    public class NUnitTestCaseImpl : NfsTestCase {

        protected IList<Type> SupportedAttributeTypes { set; get; }
        protected IList<Vji.Test.NfsTestAttribute> Attributes { set; get; }

        public NUnitTestCaseImpl() {
            SupportedAttributeTypes = new List<Type>();
            Attributes = new List<Vji.Test.NfsTestAttribute>();
        }

        private void GetClassAttributes() {
            Type type = this.GetType();
            foreach (Attribute attr in type.GetCustomAttributes(true)) {
                if (SupportedAttributeTypes.Contains(attr.GetType())) {
                    Attributes.Add((Vji.Test.NfsTestAttribute) attr);
                }
            }
        }

//        private void GetMethodAttributes() {
//            string testMethodName = (string)TestContext.Properties["TestName"];
//            Type type = this.GetType();
//            foreach (MethodInfo method in type.GetMethods()) {
//                if (method.Name == testMethodName) {
//                    foreach (Attribute attr in method.GetCustomAttributes(true)) {
//                        if (SupportedAttributeTypes.Contains(attr.GetType())) {
//                            Attributes.Add((TestAttribute) attr);
//                        }
//                    }
//                }
//            }
//        }

        private void GetAttributes() {
            GetClassAttributes();
//            GetMethodAttributes();
        }

        [SetUp]
        public void Initialize() {
            GetAttributes();
            foreach (NfsTestAttribute attribute in Attributes) {
                attribute.Initialize(this);
            }
        }

        [TearDown]
        public void Cleanup() {
            foreach (NfsTestAttribute attribute in Attributes) {
                attribute.Cleanup();
            }
        }
        
        [Test] public void HackToGetAroundNUnitReporting() {
            Assert.IsTrue(true);
        }
       
    }
}

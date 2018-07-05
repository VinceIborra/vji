using System;
using System.Collections.Generic;
using NUnit.Framework;
using Vji.Exceptions;
using Vji.Mock.Mvc;

namespace Vji.Mvc {
    
    [TestFixture]
    public class SafeViewImplTest {
        
        [Test]
        public void TestRender_ForAThrownInternalErrorException() {
            
            MockUnsafeViewImpl unsafeView = new MockUnsafeViewImpl();
            unsafeView.Exception = new InternalErrorException("A mock internal error");
            
            SafeViewImpl safeView = new SafeViewImpl();
            safeView.UnsafeView = unsafeView;
            
            IDictionary<string, object> model = new Dictionary<string, object>();
            string str = null;
            Assert.That(() => {
                str = safeView.Render(model);
            }, Throws.Nothing);
            Assert.That(str, Is.EqualTo("A mock internal error - An internal error has occurred.  Please contact system maintainer."));
        }

        [Test]
        public void TestRender_ForAThrownException() {
            
            MockUnsafeViewImpl unsafeView = new MockUnsafeViewImpl();
            unsafeView.Exception = new Exception("A mock exception");
            
            SafeViewImpl safeView = new SafeViewImpl();
            safeView.UnsafeView = unsafeView;
            
            IDictionary<string, object> model = new Dictionary<string, object>();
            string str = null;
            Assert.That(() => {
                str = safeView.Render(model);
            }, Throws.Nothing);
            Assert.That(str, Is.StringStarting("A mock exception"));
        }

    }
}

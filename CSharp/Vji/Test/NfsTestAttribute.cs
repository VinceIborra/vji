using System;

namespace Vji.Test {
    public abstract class NfsTestAttribute : Attribute {
        public abstract void Initialize(NfsTestCase testCase);
        public abstract void Cleanup();
    }
}

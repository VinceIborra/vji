using System;
using System.Collections.Generic;
using Vji.Standard.Mvc;

namespace Vji.Mock.Standard.Mvc {

    public class MockLineSourceImpl : LineSource {
        
        private Queue<string> Lines { set; get; }
        
        private void EnsureLinesAreInitialised() {
            this.Lines = new Queue<string>();
        }
        
        public void AddLine(string line) {
            this.EnsureLinesAreInitialised();
            this.Lines.Enqueue(line);
        }
        
        public string NextLine() {
            return this.Lines.Dequeue();
        }
    }
}

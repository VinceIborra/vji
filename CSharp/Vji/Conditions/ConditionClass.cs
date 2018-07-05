using System;

namespace Vji.Conditions {

  public abstract class ConditionClass : Condition {

    public abstract void Setup();
    public abstract void Teardown();

    public void RunUnder(TheCode theCode) {
      try {
        Setup();
        theCode();
      }
      finally {
        Teardown();
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vji.Conditions {
  public class CompositeConditionClass : ConditionClass, CompositeCondition {

    #region Properties
      public IList<Condition> SubConditions { set; get; }
    #endregion

    public override void Setup() {
      foreach(Condition condition in SubConditions) {
        condition.Setup();
      }
    }

    public override void Teardown() {
      foreach(Condition condition in SubConditions) {
        condition.Teardown();
      }
    }
  }
}

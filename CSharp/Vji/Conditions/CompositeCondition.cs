using System;
using System.Collections.Generic;

namespace Vji.Conditions {
  public interface CompositeCondition : Condition {
    IList<Condition> SubConditions { set; get; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System {

  public static class StringExtensions {
      public static string ToText(this string str) {
          return "\"" + str + "\"";
      }
    }
}

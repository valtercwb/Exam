using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace VolvoExam.Util
{
  public static class ExtensionMethods
  {


    public static List<SelectListItem> SetDefaultSelect(this List<SelectListItem> list)
    {
      list.Insert(0, new SelectListItem() { Text = "Select", Selected = true});

      return list;
    }
  }
}

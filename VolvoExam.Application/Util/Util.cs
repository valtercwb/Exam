using System;
using System.Collections.Generic;

namespace VolvoExam.Application.Util
{
  public class Util
  {

    /// <summary>
    /// Model year must be the current year and the subsequent year
    /// </summary>
    /// <returns></returns>
    public static List<int> GetValidTruckModelYear()
    {
      return new List<int>() { DateTime.Now.Year, DateTime.Now.Year + 1 };
    }

  }
}

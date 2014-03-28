using System;

namespace Catharsis.Domain
{
  internal static class DateTimeExtensions
  {
    public static string ToXmlString(this DateTime dateTime)
    {
      var result = dateTime.ToString("o");
      if (result[result.Length - 2] == '0')
      {
        result = result.Remove(result.Length - 2, 1);
      }
      return result;
    }
  }
}
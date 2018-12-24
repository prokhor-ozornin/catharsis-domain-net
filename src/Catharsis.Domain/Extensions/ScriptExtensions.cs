using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class ScriptExtensions
  {
    public static IQueryable<Script> Duration(this IQueryable<Script> scripts, long? from = null, long? to = null)
    {
      Assertion.NotNull(scripts);

      if (from != null)
      {
        scripts = scripts.Where(it => it.Duration >= from.Value);
      }

      if (to != null)
      {
        scripts = scripts.Where(it => it.Duration <= to.Value);
      }

      return scripts;
    }

    public static IEnumerable<Script> Duration(this IEnumerable<Script> scripts, long? from = null, long? to = null)
    {
      Assertion.NotNull(scripts);

      if (from != null)
      {
        scripts = scripts.Where(it => it != null && it.Duration >= from.Value);
      }

      if (to != null)
      {
        scripts = scripts.Where(it => it != null && it.Duration <= to.Value);
      }

      return scripts.Where(it => it != null);
    }

    public static IQueryable<Script> Executed(this IQueryable<Script> scripts, bool executed)
    {
      Assertion.NotNull(scripts);

      return scripts.Where(it => it.Executed == executed);
    }

    public static IEnumerable<Script> Executed(this IEnumerable<Script> scripts, bool executed)
    {
      Assertion.NotNull(scripts);

      return scripts.Where(it => it != null && it.Executed == executed);
    }

    public static IQueryable<Script> Name(this IQueryable<Script> scripts, string name)
    {
      Assertion.NotNull(scripts);
      Assertion.NotEmpty(name);

      return scripts.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Script> Name(this IEnumerable<Script> scripts, string name)
    {
      Assertion.NotNull(scripts);
      Assertion.NotEmpty(name);

      return scripts.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}
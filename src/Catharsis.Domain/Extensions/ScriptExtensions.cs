namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Script"/>.</para>
/// </summary>
/// <seealso cref="Script"/>
public static class ScriptExtensions
{
  public static IQueryable<Script> Executed(this IQueryable<Script> scripts, bool? executed) => scripts.Where(script => script.Executed == executed);

  public static IEnumerable<Script?> Executed(this IEnumerable<Script?> scripts, bool? executed) => scripts.Where(script => script != null && script.Executed == executed);

  public static IQueryable<Script> Name(this IQueryable<Script> scripts, string name) => scripts.Where(script => script.Name != null && script.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Script?> Name(this IEnumerable<Script?> scripts, string name) => scripts.Where(script => script?.Name != null && script.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<Script> Duration(this IQueryable<Script> scripts, long? from = null, long? to = null)
  {
    if (from != null)
    {
      scripts = scripts.Where(script => script.Duration >= from.Value);
    }

    if (to != null)
    {
      scripts = scripts.Where(script => script.Duration <= to.Value);
    }

    return scripts;
  }

  public static IEnumerable<Script?> Duration(this IEnumerable<Script?> scripts, long? from = null, long? to = null)
  {
    if (from != null)
    {
      scripts = scripts.Where(script => script != null && script.Duration >= from.Value);
    }

    if (to != null)
    {
      scripts = scripts.Where(script => script != null && script.Duration <= to.Value);
    }

    return scripts.Where(script => script != null);
  }
}
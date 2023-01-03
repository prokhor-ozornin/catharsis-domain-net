namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Person"/>.</para>
/// </summary>
/// <seealso cref="Person"/>
public static class PersonExtensions
{
  public static IQueryable<Person> Name(this IQueryable<Person> people, string name) => people.Where(person => person.FirstName != null && person.LastName != null && person.MiddleName != null && (person.FirstName.ToLower() == name.ToLower() || person.LastName.ToLower() == name.ToLower() || person.MiddleName.ToLower() == name.ToLower()));

  public static IEnumerable<Person> Name(this IEnumerable<Person> people, string name) => people.Where(person => person != null && ((person.FirstName != null && person.FirstName.ToLower() == name.ToLower()) || (person.LastName != null && person.LastName.ToLower() == name.ToLower()) || (person.MiddleName != null && person.MiddleName.ToLower() == name.ToLower())));

  public static IQueryable<Person> BirthDate(this IQueryable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      people = people.Where(person => person.BirthDate >= from.Value);
    }

    if (to != null)
    {
      people = people.Where(person => person.BirthDate <= to.Value);
    }

    return people;
  }

  public static IEnumerable<Person> BirthDate(this IEnumerable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      people = people.Where(person => person != null && person.BirthDate >= from.Value);
    }

    if (to != null)
    {
      people = people.Where(person => person != null && person.BirthDate <= to.Value);
    }

    return people.Where(person => person != null);
  }

  public static IQueryable<Person> DeathDate(this IQueryable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      people = people.Where(person => person.DeathDate >= from.Value);
    }

    if (to != null)
    {
      people = people.Where(person => person.DeathDate <= to.Value);
    }

    return people;
  }

  public static IEnumerable<Person> DeathDate(this IEnumerable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      people = people.Where(person => person != null && person.DeathDate >= from.Value);
    }

    if (to != null)
    {
      people = people.Where(person => person != null && person.DeathDate <= to.Value);
    }

    return people.Where(person => person != null);
  }
}
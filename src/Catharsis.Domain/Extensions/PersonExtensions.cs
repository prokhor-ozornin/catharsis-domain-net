namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Person"/>.</para>
/// </summary>
/// <seealso cref="Person"/>
public static class PersonExtensions
{
  public static IQueryable<Person> Name(this IQueryable<Person> people, string name) => people.Where(person => person.FirstName != null && person.LastName != null && person.MiddleName != null && (person.FirstName.ToLower() == name.ToLower() || person.LastName.ToLower() == name.ToLower() || person.MiddleName.ToLower() == name.ToLower()));

  public static IEnumerable<Person> Name(this IEnumerable<Person> people, string name) => people.Where(person => person is not null && ((person.FirstName is not null && person.FirstName.ToLower() == name.ToLower()) || (person.LastName is not null && person.LastName.ToLower() == name.ToLower()) || (person.MiddleName is not null && person.MiddleName.ToLower() == name.ToLower())));

  public static IQueryable<Person> BirthDate(this IQueryable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from is not null)
    {
      people = people.Where(person => person.BirthDate >= from.Value);
    }

    if (to is not null)
    {
      people = people.Where(person => person.BirthDate <= to.Value);
    }

    return people;
  }

  public static IEnumerable<Person> BirthDate(this IEnumerable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from is not null)
    {
      people = people.Where(person => person is not null && person.BirthDate >= from.Value);
    }

    if (to is not null)
    {
      people = people.Where(person => person is not null && person.BirthDate <= to.Value);
    }

    return people.Where(person => person is not null);
  }

  public static IQueryable<Person> DeathDate(this IQueryable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from is not null)
    {
      people = people.Where(person => person.DeathDate >= from.Value);
    }

    if (to is not null)
    {
      people = people.Where(person => person.DeathDate <= to.Value);
    }

    return people;
  }

  public static IEnumerable<Person> DeathDate(this IEnumerable<Person> people, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from is not null)
    {
      people = people.Where(person => person is not null && person.DeathDate >= from.Value);
    }

    if (to is not null)
    {
      people = people.Where(person => person is not null && person.DeathDate <= to.Value);
    }

    return people.Where(person => person is not null);
  }
}
using Catharsis.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain
{
  public static class PersonExtensions
  {
    public static IQueryable<Person> BirthDate(this IQueryable<Person> people, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(people);

      if (from != null)
      {
        people = people.Where(it => it.BirthDate >= from.Value);
      }

      if (to != null)
      {
        people = people.Where(it => it.BirthDate <= to.Value);
      }

      return people;
    }

    public static IEnumerable<Person> BirthDate(this IEnumerable<Person> people, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(people);

      if (from != null)
      {
        people = people.Where(it => it != null && it.BirthDate >= from.Value);
      }

      if (to != null)
      {
        people = people.Where(it => it != null && it.BirthDate <= to.Value);
      }

      return people.Where(it => it != null);
    }

    public static IQueryable<Person> DeathDate(this IQueryable<Person> people, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(people);

      if (from != null)
      {
        people = people.Where(it => it.DeathDate >= from.Value);
      }

      if (to != null)
      {
        people = people.Where(it => it.DeathDate <= to.Value);
      }

      return people;
    }

    public static IEnumerable<Person> DeathDate(this IEnumerable<Person> people, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(people);

      if (from != null)
      {
        people = people.Where(it => it != null && it.DeathDate >= from.Value);
      }

      if (to != null)
      {
        people = people.Where(it => it != null && it.DeathDate <= to.Value);
      }

      return people.Where(it => it != null);
    }

    public static IQueryable<Person> Name(this IQueryable<Person> people, string name)
    {
      Assertion.NotNull(people);
      Assertion.NotEmpty(name);

      name = name.ToLower();
      return people.Where(it => it.FirstName.ToLower() == name || it.LastName.ToLower() == name || it.MiddleName.ToLower() == name);
    }

    public static IEnumerable<Person> Name(this IEnumerable<Person> people, string name)
    {
      Assertion.NotNull(people);
      Assertion.NotEmpty(name);

      name = name.ToLower();
      return people.Where(it => it != null && ((it.FirstName != null && it.FirstName.ToLower() == name) || (it.LastName != null && it.LastName.ToLower() == name) || (it.MiddleName != null && it.MiddleName.ToLower() == name)));
    }
  }
}
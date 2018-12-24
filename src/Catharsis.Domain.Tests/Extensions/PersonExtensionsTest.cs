using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class PersonExtensionsTest
  {
    [Fact]
    public void birth_date_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Person>)null).BirthDate());

      var people = new[] { new Person { BirthDate = new DateTime(2000, 1, 1) }, new Person { BirthDate = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, people.BirthDate().Count());
      Assert.Equal(2, people.BirthDate(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(people.BirthDate(new DateTime(2000, 1, 3)));
      Assert.Equal(1, people.BirthDate(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, people.BirthDate(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(people.BirthDate(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, people.BirthDate(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, people.BirthDate(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void birth_date_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Person>)null).BirthDate());

      var people = new[] { null, new Person(), new Person { BirthDate = new DateTime(2000, 1, 1) }, new Person { BirthDate = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, people.BirthDate().Count());
      Assert.Equal(2, people.BirthDate(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(people.BirthDate(new DateTime(2000, 1, 3)));
      Assert.Single(people.BirthDate(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)));
      Assert.Equal(2, people.BirthDate(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(people.BirthDate(to: new DateTime(1999, 12, 31)));
      Assert.Single(people.BirthDate(to: new DateTime(2000, 1, 1)));
      Assert.Equal(2, people.BirthDate(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void death_date_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Person>)null).DeathDate());

      var people = new[] { new Person { DeathDate = new DateTime(2000, 1, 1) }, new Person { DeathDate = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, people.DeathDate().Count());
      Assert.Equal(2, people.DeathDate(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(people.DeathDate(new DateTime(2000, 1, 3)));
      Assert.Equal(1, people.DeathDate(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, people.DeathDate(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(people.DeathDate(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, people.DeathDate(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, people.DeathDate(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void death_date_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Person>)null).DeathDate());

      var people = new[] { null, new Person(), new Person { DeathDate = new DateTime(2000, 1, 1) }, new Person { DeathDate = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, people.DeathDate().Count());
      Assert.Equal(2, people.DeathDate(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(people.DeathDate(new DateTime(2000, 1, 3)));
      Assert.Single(people.DeathDate(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)));
      Assert.Equal(2, people.DeathDate(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(people.DeathDate(to: new DateTime(1999, 12, 31)));
      Assert.Single(people.DeathDate(to: new DateTime(2000, 1, 1)));
      Assert.Equal(2, people.DeathDate(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Person>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Person[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Person[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Person { FirstName = "Prokhor", LastName = "Ozornin", MiddleName = "Nikolaevich" }, new Person { FirstName = "Ilya", LastName = "Obabkov", MiddleName = "Nikolaevich" } }.AsQueryable().Name("prokhor").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Person>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Person[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Person[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new Person(), new Person { FirstName = "First" }, new Person { FirstName = "Second" } }.Name("first"));
    }
  }
}
using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PersonExtensions"/>.</para>
/// </summary>
public sealed class PersonExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="PersonExtensions.BirthDate(IQueryable{Person}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void BirthDate_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Person>) null).BirthDate()).ThrowExactly<ArgumentNullException>();

    var people = new[] {new Person {BirthDate = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Person {BirthDate = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}}.AsQueryable();
    people.BirthDate().Should().HaveCount(2);
    people.BirthDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.BirthDate(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.BirthDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.BirthDate(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.BirthDate(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.BirthDate(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.BirthDate(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PersonExtensions.BirthDate(IEnumerable{Person}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void BirthDate_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Person>) null).BirthDate()).ThrowExactly<ArgumentNullException>();

    var people = new[] {null, new Person(), new Person {BirthDate = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Person {BirthDate = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    people.BirthDate().Should().HaveCount(3);
    people.BirthDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.BirthDate(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.BirthDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.BirthDate(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.BirthDate(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.BirthDate(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.BirthDate(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PersonExtensions.DeathDate(IQueryable{Person}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void DeathDate_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Person>) null).DeathDate()).ThrowExactly<ArgumentNullException>();

    var people = new[] {new Person {DeathDate = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Person {DeathDate = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}}.AsQueryable();
    people.DeathDate().Should().HaveCount(2);
    people.DeathDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.DeathDate(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.DeathDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.DeathDate(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.DeathDate(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.DeathDate(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.DeathDate(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PersonExtensions.DeathDate(IQueryable{Person}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void DeathDate_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Person>) null).DeathDate()).ThrowExactly<ArgumentNullException>();

    var people = new[] {null, new Person(), new Person {DeathDate = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Person {DeathDate = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    people.DeathDate().Should().HaveCount(3);
    people.DeathDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.DeathDate(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.DeathDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.DeathDate(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    people.DeathDate(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    people.DeathDate(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    people.DeathDate(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PersonExtensions.Name(IQueryable{Person}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Person>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Person>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Person>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Person {FirstName = "Prokhor", LastName = "Ozornin", MiddleName = "Nikolaevich"}, new Person {FirstName = "Ilya", LastName = "Obabkov", MiddleName = "Nikolaevich"}}.AsQueryable().Name("prokhor").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PersonExtensions.Name(IEnumerable{Person}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Person>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Person>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Person>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Person(), new Person {FirstName = "First"}, new Person {FirstName = "Second"}}.Name("first").Should().ContainSingle();
  }
}
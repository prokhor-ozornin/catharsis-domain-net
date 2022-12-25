using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Person"/>.</para>
/// </summary>
public sealed class PersonTest : EntityTest<Person>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Person.FirstName"/> property.</para>
  /// </summary>
  [Fact]
  public void FirstName_Property()
  {
    new Person { FirstName = Guid.Empty.ToString() }.FirstName.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Person.LastName"/> property.</para>
  /// </summary>
  [Fact]
  public void LastName_Property()
  {
    new Person { LastName = Guid.Empty.ToString() }.LastName.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Person.MiddleName"/> property.</para>
  /// </summary>
  [Fact]
  public void MiddleName_Property()
  {
    new Person { MiddleName = Guid.Empty.ToString() }.MiddleName.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Person.BirthDate"/> property.</para>
  /// </summary>
  [Fact]
  public void BirthDate_Property()
  {
    new Person { BirthDate = DateTimeOffset.MaxValue }.BirthDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Person.DeathDate"/> property.</para>
  /// </summary>
  [Fact]
  public void DeathDate_Property()
  {
    new Person { DeathDate = DateTimeOffset.MaxValue }.DeathDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Person()"/>
  [Fact]
  public void Constructors()
  {
    var person = new Person();

    person.Id.Should().BeNull();
    person.Uuid.Should().NotBeNull();
    person.Version.Should().BeNull();
    person.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    person.UpdatedOn.Should().BeNull();

    person.FirstName.Should().BeNull();
    person.LastName.Should().BeNull();
    person.MiddleName.Should().BeNull();
    person.BirthDate.Should().BeNull();
    person.DeathDate.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Person.CompareTo(Person)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Person.FirstName), "first", "second");
    TestCompareTo(nameof(Person.LastName), "first", "second");
    TestCompareTo(nameof(Person.MiddleName), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Person.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Person().ToString().Should().BeEmpty();
    new Person { FirstName = "Prokhor", LastName = "Ozornin", MiddleName = "Nikolaevich" }.ToString().Should().Be("Ozornin Prokhor Nikolaevich");
    new Person { FirstName = "Prokhor", LastName = "Ozornin" }.ToString().Should().Be("Ozornin Prokhor");
    new Person { FirstName = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}
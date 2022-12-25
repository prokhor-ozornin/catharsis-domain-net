using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AddressExtensions"/>.</para>
/// </summary>
public sealed class AddressExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="AddressExtensions.City(IQueryable{Address}, City?)"/> method.</para>
  /// </summary>
  [Fact]
  public void City_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Address>) null!).City(new City())).ThrowExactly<ArgumentNullException>();

    new[] {new Address {City = new City {Id = 1}}, new Address {City = new City {Id = 2}}}.AsQueryable().City(new City {Id = 1}).Should().ContainSingle();
    new[] {new Address {City = new City {Id = 1}}, new Address {City = null}}.AsQueryable().City(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AddressExtensions.City(IEnumerable{Address}, City?)"/> method.</para>
  /// </summary>
  [Fact]
  public void City_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Address>) null!).City(new City())).ThrowExactly<ArgumentNullException>();

    new[] {null, new Address {City = new City {Name = "first"}}, new Address {City = new City {Name = "second"}}}.City(new City {Name = "first"}).Should().ContainSingle();
    new[] {null, new Address(), new Address {City = new City {Name = "first"}}}.City(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AddressExtensions.Name(IQueryable{Address}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Address>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Address>().AsQueryable().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Address>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Address {Name = "First"}, new Address {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AddressExtensions.Name(IQueryable{Address}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Address>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Address>().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Address>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Address(), new Address {Name = "First"}, new Address {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}
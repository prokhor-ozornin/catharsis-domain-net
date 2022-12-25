using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Country"/>.</para>
/// </summary>
public sealed class CountryTest : EntityTest<Country>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Country.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Country { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Country.Language"/> property.</para>
  /// </summary>
  [Fact]
  public void Language_Property()
  {
    new Country { Language = Guid.Empty.ToString() }.Language.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Country.Currency"/> property.</para>
  /// </summary>
  [Fact]
  public void Currency_Property()
  {
    new Country { Currency = Guid.Empty.ToString() }.Currency.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Country.IsoCode"/> property.</para>
  /// </summary>
  [Fact]
  public void IsoCode_Property()
  {
    new Country { IsoCode = Guid.Empty.ToString() }.IsoCode.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Country.CurrencyCode"/> property.</para>
  /// </summary>
  [Fact]
  public void CurrencyCode_Property()
  {
    new Country { CurrencyCode = Guid.Empty.ToString() }.CurrencyCode.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Country()"/>
  [Fact]
  public void Constructors()
  {
    var country = new Country();

    country.Id.Should().BeNull();
    country.Uuid.Should().NotBeNull();
    country.Version.Should().BeNull();
    country.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    country.UpdatedOn.Should().BeNull();

    country.Name.Should().BeNull();
    country.Language.Should().BeNull();
    country.Currency.Should().BeNull();
    country.IsoCode.Should().BeNull();
    country.CurrencyCode.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Country.CompareTo(Country)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Country.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Country.Equals(Country)"/></description></item>
  ///     <item><description><see cref="Country.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Country.IsoCode), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Country.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Country.IsoCode), "first", "second");
  }


  /// <summary>
  ///   <para>Performs testing of <see cref="Country.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Country().ToString().Should().BeEmpty();
    new Country { Name = string.Empty }.ToString().Should().BeEmpty();
    new Country { Name = " " }.ToString().Should().BeEmpty();
    new Country { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}
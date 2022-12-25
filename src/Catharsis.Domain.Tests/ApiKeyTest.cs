using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ApiKey"/>.</para>
/// </summary>
public sealed class ApiKeyTest : EntityTest<ApiKey>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.Value"/> property.</para>
  /// </summary>
  [Fact]
  public void Value_Property()
  {
    new ApiKey { Value = Guid.Empty.ToString() }.Value.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new ApiKey { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.Contact"/> property.</para>
  /// </summary>
  [Fact]
  public void Contact_Property()
  {
    var contact = new Contact();
    new ApiKey { Contact = contact }.Contact.Should().BeSameAs(contact);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.AppName"/> property.</para>
  /// </summary>
  [Fact]
  public void AppName_Property()
  {
    new ApiKey { AppName = Guid.Empty.ToString() }.AppName.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.AppDomain"/> property.</para>
  /// </summary>
  [Fact]
  public void AppDomain_Property()
  {
    new ApiKey { AppDomain = Guid.Empty.ToString() }.AppDomain.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.AppDescription"/> property.</para>
  /// </summary>
  [Fact]
  public void AppDescription_Property()
  {
    new ApiKey { AppDescription = Guid.Empty.ToString() }.AppDescription.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ApiKey()"/>
  [Fact]
  public void Constructors()
  {
    var apiKey = new ApiKey();

    apiKey.Id.Should().BeNull();
    apiKey.Uuid.Should().NotBeNull();
    apiKey.Version.Should().BeNull();
    apiKey.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    apiKey.UpdatedOn.Should().BeNull();

    apiKey.Value.Should().NotBeNullOrEmpty();
    apiKey.Name.Should().BeNull();
    apiKey.Contact.Should().BeNull();
    apiKey.AppName.Should().BeNull();
    apiKey.AppDomain.Should().BeNull();
    apiKey.AppDescription.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.CompareTo(ApiKey)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(ApiKey.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ApiKey.Equals(ApiKey)"/></description></item>
  ///     <item><description><see cref="ApiKey.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(ApiKey.Value), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(ApiKey.Value), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKey.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new ApiKey().ToString().Should().NotBeNullOrEmpty();
    new ApiKey { Value = string.Empty }.ToString().Should().BeEmpty();
    new ApiKey { Value = " " }.ToString().Should().BeEmpty();
    new ApiKey { Value = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}
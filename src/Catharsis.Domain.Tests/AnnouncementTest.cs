using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Announcement"/>.</para>
/// </summary>
public sealed class AnnouncementTest : EntityTest<Announcement>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Announcement { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.Text"/> property.</para>
  /// </summary>
  [Fact]
  public void Text_Property()
  {
    new Announcement { Text = Guid.Empty.ToString() }.Text.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.Image"/> property.</para>
  /// </summary>
  [Fact]
  public void Image_Property()
  {
    var image = new Image();
    new Announcement { Image = image }.Image.Should().BeSameAs(image);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.Price"/> property.</para>
  /// </summary>
  [Fact]
  public void Price_Property()
  {
    new Announcement { Price = decimal.MaxValue }.Price.Should().Be(decimal.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.PriceCurrency"/> property.</para>
  /// </summary>
  [Fact]
  public void PriceCurrency_Property()
  {
    new Announcement { PriceCurrency = Guid.Empty.ToString() }.PriceCurrency.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Announcement()"/>
  [Fact]
  public void Constructors()
  {
    var announcement = new Announcement();

    announcement.Id.Should().BeNull();
    announcement.Uuid.Should().NotBeNull();
    announcement.Version.Should().BeNull();
    announcement.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    announcement.UpdatedOn.Should().BeNull();
    
    announcement.Name.Should().BeNull();
    announcement.Text.Should().BeNull();
    announcement.Image.Should().BeNull();
    announcement.Price.Should().BeNull();
    announcement.PriceCurrency.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.CompareTo(Announcement)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Announcement.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Announcement.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Announcement().ToString().Should().BeEmpty();
    new Announcement { Name = string.Empty }.ToString().Should().BeEmpty();
    new Announcement { Name = " " }.ToString().Should().BeEmpty();
    new Announcement { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}
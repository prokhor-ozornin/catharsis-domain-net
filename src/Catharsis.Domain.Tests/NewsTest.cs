using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="News"/>.</para>
/// </summary>
public sealed class NewsTest : EntityTest<News>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="News.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new News { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.Image"/> property.</para>
  /// </summary>
  [Fact]
  public void Image_Property()
  {
    var image = new Image();
    new News { Image = image }.Image.Should().BeSameAs(image);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.Annotation"/> property.</para>
  /// </summary>
  [Fact]
  public void Annotation_Property()
  {
    new News { Annotation = Guid.Empty.ToString() }.Annotation.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.Text"/> property.</para>
  /// </summary>
  [Fact]
  public void Text_Property()
  {
    new News { Text = Guid.Empty.ToString() }.Text.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.Tags"/> property.</para>
  /// </summary>
  [Fact]
  public void Tags_Property()
  {
    var tags = new HashSet<Tag>();
    new News { Tags = tags }.Tags.Should().BeSameAs(tags);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="News()"/>
  [Fact]
  public void Constructors()
  {
    var news = new News();

    news.Id.Should().BeNull();
    news.Uuid.Should().NotBeNull();
    news.Version.Should().BeNull();
    news.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    news.UpdatedOn.Should().BeNull();

    news.Name.Should().BeNull();
    news.Image.Should().BeNull();
    news.Annotation.Should().BeNull();
    news.Text.Should().BeNull();
    news.Tags.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.CompareTo(News)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(News.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="News.Equals(News)"/></description></item>
  ///     <item><description><see cref="News.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(News.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestEquality(nameof(News.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(News.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestHashCode(nameof(News.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="News.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new News().ToString().Should().BeEmpty();
    new News { Name = string.Empty }.ToString().Should().BeEmpty();
    new News { Name = " " }.ToString().Should().BeEmpty();
    new News { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}
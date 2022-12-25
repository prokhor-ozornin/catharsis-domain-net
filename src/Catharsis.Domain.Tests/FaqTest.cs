using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Faq"/>.</para>
/// </summary>
public sealed class FaqTest : EntityTest<Faq>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Faq.Question"/> property.</para>
  /// </summary>
  [Fact]
  public void Question_Property()
  {
    new Faq { Question = Guid.Empty.ToString() }.Question.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Faq.Answer"/> property.</para>
  /// </summary>
  [Fact]
  public void Answer_Property()
  {
    new Faq { Answer = Guid.Empty.ToString() }.Answer.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Faq()"/>
  [Fact]
  public void Constructors()
  {
    var faq = new Faq();

    faq.Id.Should().BeNull();
    faq.Uuid.Should().NotBeNull();
    faq.Version.Should().BeNull();
    faq.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    faq.UpdatedOn.Should().BeNull();

    faq.Question.Should().BeNull();
    faq.Answer.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Faq.CompareTo(Faq)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Faq.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Faq.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Faq().ToString().Should().BeEmpty();
    new Faq { Question = string.Empty }.ToString().Should().BeEmpty();
    new Faq { Question = " " }.ToString().Should().BeEmpty();
    new Faq { Question = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}
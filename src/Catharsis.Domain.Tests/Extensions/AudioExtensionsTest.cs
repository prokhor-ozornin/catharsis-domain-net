using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AudioExtensions"/>.</para>
/// </summary>
public sealed class AudioExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="AudioExtensions.Bitrate(IQueryable{Audio}, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Bitrate_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Audio>) null).Bitrate(0)).ThrowExactly<ArgumentNullException>();

    new[] {new Audio {Bitrate = 32}, new Audio {Bitrate = 64}}.AsQueryable().Bitrate(32).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AudioExtensions.Bitrate(IEnumerable{Audio}, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Bitrate_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Audio>) null).Bitrate(0)).ThrowExactly<ArgumentNullException>();

    new[] {null, new Audio(), new Audio {Bitrate = 32}, new Audio {Bitrate = 64}}.Bitrate(32).Should().ContainSingle();
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ITaggableExtensions"/>.</para>
  /// </summary>
  public sealed class ITaggableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITaggableExtensions.Tag{T}(IQueryable{T}, string)"/></description></item>
    ///     <item><description><see cref="ITaggableExtensions.Tag{T}(IEnumerable{T}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Tag_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<TaggableEntity>)null).Tag("tag"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<TaggableEntity>)null).Tag("tag"));

      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<TaggableEntity>().AsQueryable().Tag(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<TaggableEntity>().Tag(string.Empty));

      Assert.Equal(1, new[] { new TaggableEntity { Tags = new List<string> { "first" } }, new TaggableEntity { Tags = new List<string> { "second" } } }.AsQueryable().Tag("first").Count());
      Assert.Equal(1, new[] { null, new TaggableEntity { Tags = new List<string> { "first" } }, null, new TaggableEntity { Tags = new List<string> { "second" } } }.Tag("first").Count());
    }

    private sealed class TaggableEntity : ITaggable
    {
      public List<string> Tags { get; set; }
    }
  }
}
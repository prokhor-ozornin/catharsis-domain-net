using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class MediaExtensionsTest
  {
    [Fact]
    public void content_type_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Media>)null).ContentType("locale"));
      Assert.Throws<ArgumentNullException>(() => new Media[] { }.AsQueryable().ContentType(null));
      Assert.Throws<ArgumentException>(() => new Media[] { }.AsQueryable().ContentType(string.Empty));

      Assert.Equal(1, new[] { new Media { ContentType = "First" }, new Media { ContentType = "Second" } }.AsQueryable().ContentType("first").Count());
    }

    [Fact]
    public void content_type_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Media>)null).ContentType("name"));
      Assert.Throws<ArgumentNullException>(() => new Media[] { }.ContentType(null));
      Assert.Throws<ArgumentException>(() => new Media[] { }.ContentType(string.Empty));

      Assert.Single(new[] { null, new Media(), new Media { ContentType = "First" }, new Media { ContentType = "Second" } }.ContentType("first"));
    }

    [Fact]
    public void duration_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Media>)null).Duration());

      var medias = new[] { new Media { Duration = 1 }, new Media { Duration = 2 } }.AsQueryable();
      Assert.Equal(2, medias.Duration().Count());
      Assert.Equal(2, medias.Duration(0).Count());
      Assert.Empty(medias.Duration(3));
      Assert.Equal(1, medias.Duration(0, 1).Count());
      Assert.Equal(2, medias.Duration(1, 2).Count());
      Assert.Empty(medias.Duration(to: 0));
      Assert.Equal(1, medias.Duration(to: 1).Count());
      Assert.Equal(2, medias.Duration(to: 3).Count());
    }

    [Fact]
    public void duration_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Media>)null).Duration());

      var medias = new[] { null, new Media(), new Media { Duration = 1 }, new Media { Duration = 2 } };
      Assert.Equal(3, medias.Duration().Count());
      Assert.Equal(2, medias.Duration(0).Count());
      Assert.Empty(medias.Duration(3));
      Assert.Single(medias.Duration(0, 1));
      Assert.Equal(2, medias.Duration(1, 2).Count());
      Assert.Empty(medias.Duration(to: 0));
      Assert.Single(medias.Duration(to: 1));
      Assert.Equal(2, medias.Duration(to: 3).Count());
    }

    [Fact]
    public void height_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Media>)null).Height());

      var medias = new[] { new Media { Height = 1 }, new Media { Height = 2 } }.AsQueryable();
      Assert.Equal(2, medias.Height().Count());
      Assert.Equal(2, medias.Height(0).Count());
      Assert.Empty(medias.Height(3));
      Assert.Equal(1, medias.Height(0, 1).Count());
      Assert.Equal(2, medias.Height(1, 2).Count());
      Assert.Empty(medias.Height(to: 0));
      Assert.Equal(1, medias.Height(to: 1).Count());
      Assert.Equal(2, medias.Height(to: 3).Count());
    }

    [Fact]
    public void height_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Media>)null).Height());

      var medias = new[] { null, new Media(), new Media { Height = 1 }, new Media { Height = 2 } };
      Assert.Equal(3, medias.Height().Count());
      Assert.Equal(2, medias.Height(0).Count());
      Assert.Empty(medias.Height(3));
      Assert.Single(medias.Height(0, 1));
      Assert.Equal(2, medias.Height(1, 2).Count());
      Assert.Empty(medias.Height(to: 0));
      Assert.Single(medias.Height(to: 1));
      Assert.Equal(2, medias.Height(to: 3).Count());
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Media>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Media[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Media[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Media { Name = "First" }, new Media { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Media>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Media[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Media[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new Media(), new Media { Name = "First" }, new Media { Name = "Second" } }.Name("f"));
    }

    [Fact]
    public void width_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Media>)null).Width());

      var medias = new[] { new Media { Width = 1 }, new Media { Width = 2 } }.AsQueryable();
      Assert.Equal(2, medias.Width().Count());
      Assert.Equal(2, medias.Width(0).Count());
      Assert.Empty(medias.Width(3));
      Assert.Equal(1, medias.Width(0, 1).Count());
      Assert.Equal(2, medias.Width(1, 2).Count());
      Assert.Empty(medias.Width(to: 0));
      Assert.Equal(1, medias.Width(to: 1).Count());
      Assert.Equal(2, medias.Width(to: 3).Count());
    }

    [Fact]
    public void width_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Media>)null).Width());

      var medias = new[] { null, new Media(), new Media { Width = 1 }, new Media { Width = 2 } };
      Assert.Equal(3, medias.Width().Count());
      Assert.Equal(2, medias.Width(0).Count());
      Assert.Empty(medias.Width(3));
      Assert.Single(medias.Width(0, 1));
      Assert.Equal(2, medias.Width(1, 2).Count());
      Assert.Empty(medias.Width(to: 0));
      Assert.Single(medias.Width(to: 1));
      Assert.Equal(2, medias.Width(to: 3).Count());
    }
  }
}
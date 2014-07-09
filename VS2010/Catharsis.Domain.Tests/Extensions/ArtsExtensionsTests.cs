using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ArtExtensions"/>.</para>
  /// </summary>
  public sealed class ArtsExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ArtExtensions.Album(IQueryable{Art}, ArtsAlbum)"/></description></item>
    ///     <item><description><see cref="ArtExtensions.Album(IEnumerable{Art}, ArtsAlbum)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Album_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Art>) null).Album(new ArtsAlbum()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Art>)null).Album(new ArtsAlbum()));

      Assert.False(Enumerable.Empty<Art>().AsQueryable().Album(null).Any());
      Assert.False(Enumerable.Empty<Art>().Album(null).Any());

      Assert.False(Enumerable.Empty<Art>().AsQueryable().Album(new ArtsAlbum()).Any());
      Assert.False(Enumerable.Empty<Art>().Album(new ArtsAlbum()).Any());

      Assert.Equal(1, new[] { new Art { Album = new ArtsAlbum { Id = 1 } }, new Art { Album = new ArtsAlbum { Id = 2 } } }.AsQueryable().Album(new ArtsAlbum { Id = 2 }).Count());
      Assert.Equal(1, new[] { null, new Art { Album = new ArtsAlbum { Name = "first" } }, null, new Art { Album = new ArtsAlbum { Name = "second" } } }.Album(new ArtsAlbum { Name = "first" }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ArtExtensions.Material(IQueryable{Art}, string)"/></description></item>
    ///     <item><description><see cref="ArtExtensions.Material(IEnumerable{Art}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Material_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Art>) null).Material("Material"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Art>)null).Material("Material"));

      Assert.False(Enumerable.Empty<Art>().Material(null).Any());
      Assert.False(Enumerable.Empty<Art>().Material(string.Empty).Any());

      Assert.Equal(1, new[] { null, new Art { Material = "first" }, null, new Art { Material = "second" } }.Material("first").Count());
    }
  }
}
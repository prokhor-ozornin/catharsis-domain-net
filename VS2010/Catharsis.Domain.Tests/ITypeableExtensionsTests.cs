using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ITypeableExtensions"/>.</para>
  /// </summary>
  public sealed class ITypeableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITypeableExtensions.Type{T}(IQueryable{T}, int)"/></description></item>
    ///     <item><description><see cref="ITypeableExtensions.Type{T}(IEnumerable{T}, int)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Name_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<TypeableEntity>) null).Type(0));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<TypeableEntity>) null).Type(0));

      Assert.Equal(1, new[] { new TypeableEntity { Type = 1 }, new TypeableEntity { Type = 2 } }.AsQueryable().Type(1).Count());
      Assert.Equal(1, new[] { null, new TypeableEntity { Type = 1 }, null, new TypeableEntity { Type = 2 } }.Type(1).Count());
    }

    private sealed class TypeableEntity : ITypeable
    {
      public int Type { get; set; }
    }
  }
}
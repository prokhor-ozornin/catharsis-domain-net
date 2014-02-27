using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IEntityExtensions"/>.</para>
  /// </summary>
  public sealed class IEntityExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IEntityExtensions.WithId{ENTITY}(IQueryable{ENTITY}, long)"/></description></item>
    ///     <item><description><see cref="IEntityExtensions.WithId{ENTITY}(IEnumerable{ENTITY}, long)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void WithId_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>) null).WithId(1));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).WithId(1));

      Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<Entity>().AsQueryable().WithId(1));
      Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<Entity>().WithId(1));

      Assert.Equal(1, new[] { new Entity { Id = 1 }, new Entity { Id = 2 } }.AsQueryable().WithId(1).Id);
      Assert.Equal(1, new[] { null, new Entity { Id = 1 }, null, new Entity { Id = 2 } }.WithId(1).Id);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IEntityExtensions.Exists{ENTITY}(IQueryable{ENTITY}, long)"/></description></item>
    ///     <item><description><see cref="IEntityExtensions.Exists{ENTITY}(IEnumerable{ENTITY}, long)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Exists_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>)null).Exists(1));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).Exists(1));

      Assert.False(Enumerable.Empty<Entity>().AsQueryable().Exists(1));
      Assert.False(Enumerable.Empty<Entity>().Exists(1));
      
      Assert.True(new[] { new Entity { Id = 1 } }.AsQueryable().Exists(1));
      Assert.True(new[] { null, new Entity { Id = 1 } }.Exists(1));
    }

    private sealed class Entity : IEntity
    {
      public long Id { get; set; }

      public long Version { get; set; }
    }
  }
}
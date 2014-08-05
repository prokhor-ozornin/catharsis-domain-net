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
    ///     <item><description><see cref="IEntityExtensions.Id{ENTITY}(IQueryable{ENTITY}, long)"/></description></item>
    ///     <item><description><see cref="IEntityExtensions.Id{ENTITY}(IEnumerable{ENTITY}, long)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Id_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>) null).Id(1));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).Id(1));

      Assert.Null(Enumerable.Empty<Entity>().AsQueryable().Id(1));
      Assert.Null(Enumerable.Empty<Entity>().Id(1));

      Assert.Equal(1, new[] { new Entity { Id = 1 }, new Entity { Id = 2 } }.AsQueryable().Id(1).Id);
      Assert.Equal(1, new[] { null, new Entity { Id = 1 }, null, new Entity { Id = 2 } }.Id(1).Id);
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

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IEntityExtensions.RandomEntity{ENTITY}(IEnumerable{ENTITY})"/></description></item>
    ///     <item><description><see cref="IEntityExtensions.RandomEntity{ENTITY}(IQueryable{ENTITY})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void RandomEntity_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>) null).RandomEntity());
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>)null).RandomEntity());

      Assert.Null(Enumerable.Empty<IEntity>().RandomEntity());
      var element = new Entity();
      Assert.True(ReferenceEquals(new[] { element }.RandomEntity(), element));
      var elements = new[] { new Entity(), new Entity() };
      Assert.True(elements.Contains(elements.RandomEntity()));

      Assert.Null(Enumerable.Empty<IEntity>().AsQueryable().RandomEntity());
      element = new Entity();
      Assert.True(ReferenceEquals(new[] { element }.AsQueryable().RandomEntity(), element));
      elements = new[] { new Entity(), new Entity() };
      Assert.True(elements.AsQueryable().Contains(elements.RandomEntity()));
    }

    private sealed class Entity : IEntity
    {
      public long Id { get; set; }

      public long Version { get; set; }
    }
  }
}
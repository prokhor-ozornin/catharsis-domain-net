using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class IEntityExtensionsTests
  {
    [Fact]
    public void created_on_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>)null).CreatedOn());

      var entities = new[] { new Entity { CreatedOn = new DateTime(2000, 1, 1) }, new Entity { CreatedOn = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, entities.CreatedOn().Count());
      Assert.Equal(2, entities.CreatedOn(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entities.CreatedOn(new DateTime(2000, 1, 3)));
      Assert.Equal(1, entities.CreatedOn(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.CreatedOn(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entities.CreatedOn(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, entities.CreatedOn(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.CreatedOn(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void created_on_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).CreatedOn());

      var entities = new[] { null, new Entity(), new Entity { CreatedOn = new DateTime(2000, 1, 1) }, new Entity { CreatedOn = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, entities.CreatedOn().Count());
      Assert.Equal(2, entities.CreatedOn(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entities.CreatedOn(new DateTime(2000, 1, 3)));
      Assert.Equal(1, entities.CreatedOn(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.CreatedOn(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entities.CreatedOn(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, entities.CreatedOn(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.CreatedOn(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void id()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>) null).Id(1));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).Id(1));

      Assert.Null(Enumerable.Empty<Entity>().AsQueryable().Id(1));
      Assert.Null(Enumerable.Empty<Entity>().Id(1));

      Assert.Equal(1, new[] { new Entity { Id = 1 }, new Entity { Id = 2 } }.AsQueryable().Id(1).Id);
      Assert.Equal(1, new[] { null, new Entity { Id = 1 }, null, new Entity { Id = 2 } }.Id(1).Id);
    }

    [Fact]
    public void random_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>)null).Random());

      Assert.Null(Enumerable.Empty<IEntity>().AsQueryable().Random());

      var first = new Entity { Id = 1 };
      var second = new Entity { Id = 2 };
      var entities = new IEntity[] { first, second }.AsQueryable();
      Assert.Same(first, new IEntity[] { first }.Random());
      Assert.Contains(entities.Random(), entities);
    }

    [Fact]
    public void random_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).Random());

      Assert.Null(Enumerable.Empty<IEntity>().Random());

      var first = new Entity { Id = 1 };
      var second = new Entity { Id = 2 };
      var entities = new IEntity[] { first, second };
      Assert.Same(first, new IEntity[] { first }.Random());
      Assert.Contains(entities.Random(), entities);
    }

    [Fact]
    public void updated_on_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<IEntity>)null).UpdatedOn());

      var entities = new[] { new Entity { UpdatedOn = new DateTime(2000, 1, 1) }, new Entity { UpdatedOn = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, entities.UpdatedOn().Count());
      Assert.Equal(2, entities.UpdatedOn(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entities.UpdatedOn(new DateTime(2000, 1, 3)));
      Assert.Equal(1, entities.UpdatedOn(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.UpdatedOn(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entities.UpdatedOn(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, entities.UpdatedOn(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.UpdatedOn(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void updated_on_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<IEntity>)null).UpdatedOn());

      var entities = new[] { null, new Entity(), new Entity { UpdatedOn = new DateTime(2000, 1, 1) }, new Entity { UpdatedOn = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, entities.UpdatedOn().Count());
      Assert.Equal(2, entities.UpdatedOn(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entities.UpdatedOn(new DateTime(2000, 1, 3)));
      Assert.Equal(1, entities.UpdatedOn(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.UpdatedOn(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entities.UpdatedOn(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, entities.UpdatedOn(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entities.UpdatedOn(to: new DateTime(2000, 1, 3)).Count());
    }

    private sealed class Entity : IEntity
    {
      public DateTime? CreatedOn { get; set; }

      public long? Id { get; set; }

      public long? Version { get; set; }

      public DateTime? UpdatedOn { get; set; }
    }
  }
}
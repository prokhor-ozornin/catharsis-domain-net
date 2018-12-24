using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ScriptExtensionsTests
  {
    [Fact]
    public void duration_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Script>)null).Duration());

      var scripts = new[] { new Script { Duration = 1 }, new Script { Duration = 2 } }.AsQueryable();
      Assert.Equal(2, scripts.Duration().Count());
      Assert.Equal(2, scripts.Duration(0).Count());
      Assert.Empty(scripts.Duration(3));
      Assert.Equal(1, scripts.Duration(0, 1).Count());
      Assert.Equal(2, scripts.Duration(1, 2).Count());
      Assert.Empty(scripts.Duration(to: 0));
      Assert.Equal(1, scripts.Duration(to: 1).Count());
      Assert.Equal(2, scripts.Duration(to: 3).Count());
    }

    [Fact]
    public void duration_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Script>)null).Duration());

      var downloads = new[] { null, new Script(), new Script { Duration = 1 }, new Script { Duration = 2 } };
      Assert.Equal(3, downloads.Duration().Count());
      Assert.Equal(2, downloads.Duration(0).Count());
      Assert.Empty(downloads.Duration(3));
      Assert.Single(downloads.Duration(0, 1));
      Assert.Equal(2, downloads.Duration(1, 2).Count());
      Assert.Empty(downloads.Duration(to: 0));
      Assert.Single(downloads.Duration(to: 1));
      Assert.Equal(2, downloads.Duration(to: 3).Count());
    }

    [Fact]
    public void executed_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Script>)null).Executed(true));

      Assert.Equal(1, new[] { new Script { Executed = false }, new Script { Executed = true } }.AsQueryable().Executed(true).Count());
    }

    [Fact]
    public void executed_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Script>)null).Executed(true));

      Assert.Single(new[] { null, new Script(), new Script { Executed = false }, new Script { Executed = true } }.Executed(true));
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Script>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Script[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Script[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Script { Name = "First" }, new Script { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Script>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Script[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Script[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new Script(), new Script { Name = "First" }, new Script { Name = "Second" } }.Name("f"));
    }
  }
}
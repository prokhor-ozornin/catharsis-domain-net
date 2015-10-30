using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class SettingExtensionsTests
  {
    [Fact]
    public void for_name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Setting>)null).ForName("name"));
      Assert.Throws<ArgumentNullException>(() => new Setting[] { }.AsQueryable().ForName(null));
      Assert.Throws<ArgumentException>(() => new Setting[] { }.AsQueryable().ForName(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Setting { Name = "Name" }, new Setting { Name = "name" } }.AsQueryable().ForName("name"));

      Assert.Null(new Setting[] { }.AsQueryable().ForName("name"));
      Assert.NotNull(new[] { new Setting { Name = "First" }, new Setting { Name = "Second" } }.AsQueryable().ForName("first"));
    }

    [Fact]
    public void for_name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Setting>)null).ForName("name"));
      Assert.Throws<ArgumentNullException>(() => new Setting[] { }.ForName(null));
      Assert.Throws<ArgumentException>(() => new Setting[] { }.ForName(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Setting { Name = "Name" }, new Setting { Name = "name" } }.ForName("name"));

      Assert.Null(new Setting[] { }.ForName("name"));
      Assert.NotNull(new[] { new Setting { Name = "First", Value = "value" }, new Setting { Name = "Second" } }.ForName("first"));
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Setting>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Setting[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Setting[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Setting { Name = "First" }, new Setting { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Setting>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Setting[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Setting[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new Setting(), new Setting { Name = "First" }, new Setting { Name = "Second" } }.Name("f").Count());
    }

    [Fact]
    public void value_of_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Setting>)null).ValueOf("name"));
      Assert.Throws<ArgumentNullException>(() => new Setting[] { }.AsQueryable().ValueOf(null));
      Assert.Throws<ArgumentException>(() => new Setting[] { }.AsQueryable().ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Setting { Name = "Name" }, new Setting { Name = "name" } }.AsQueryable().ValueOf("name"));

      Assert.Null(new Setting[] { }.AsQueryable().ValueOf("name"));
      Assert.NotNull(new[] { new Setting { Name = "First", Value = "value" }, new Setting { Name = "Second" } }.AsQueryable().ValueOf("first"));
    }

    [Fact]
    public void value_of_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Setting>)null).ValueOf("name"));
      Assert.Throws<ArgumentNullException>(() => new Setting[] { }.ValueOf(null));
      Assert.Throws<ArgumentException>(() => new Setting[] { }.ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Setting { Name = "Name" }, new Setting { Name = "name" } }.ValueOf("name"));

      Assert.Null(new Setting[] { }.ValueOf("name"));
      Assert.NotNull(new[] { new Setting { Name = "First", Value = "value" }, new Setting { Name = "Second" } }.ValueOf("first"));
    }
  }
}
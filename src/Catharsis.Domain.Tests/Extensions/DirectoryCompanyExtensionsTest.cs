using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /*public sealed class DirectoryCompanyExtensionsTest
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<DirectoryCompany>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new DirectoryCompany[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new DirectoryCompany[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new DirectoryCompany { Name = "First" }, new DirectoryCompany { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<DirectoryCompany>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new DirectoryCompany[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new DirectoryCompany[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new DirectoryCompany(), new DirectoryCompany { Name = "First" }, new DirectoryCompany { Name = "Second" } }.Name("f").Count());
    }
  }*/
}
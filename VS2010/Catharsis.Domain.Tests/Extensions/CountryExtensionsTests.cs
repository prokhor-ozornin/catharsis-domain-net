using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="CountryExtensions"/>.</para>
  /// </summary>
  public sealed class CountryExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="CountryExtensions.IsoCode(IQueryable{Country}, string)"/></description></item>
    ///     <item><description><see cref="CountryExtensions.IsoCode(IEnumerable{Country}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void IsoCode_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Country>) null).IsoCode("isoCode"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Country>)null).IsoCode("isoCode"));
      
      Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<Country>().IsoCode(null));
      Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<Country>().IsoCode(string.Empty));

      Assert.Equal("first", new[] { new Country { IsoCode = "first" }, new Country { IsoCode = "second" } }.IsoCode("first").IsoCode);
      Assert.Equal("first", new[] { null, new Country { IsoCode = "first" }, null, new Country { IsoCode = "second" } }.IsoCode("first").IsoCode);
    }
  }
}
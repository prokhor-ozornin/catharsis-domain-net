using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ILocalizableExtensions"/>.</para>
  /// </summary>
  public sealed class ILocalizableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ILocalizableExtensions.Language{T}(IQueryable{T}, string)"/></description></item>
    ///     <item><description><see cref="ILocalizableExtensions.Language{T}(IEnumerable{T}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Language_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<LocalizableEntity>)null).Language("currency"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<LocalizableEntity>)null).Language("currency"));

      Assert.False(Enumerable.Empty<LocalizableEntity>().Language(null).Any());
      Assert.False(Enumerable.Empty<LocalizableEntity>().Language(string.Empty).Any());

      Assert.Equal(1, new[] { new LocalizableEntity { Language = "first" }, new LocalizableEntity { Language = "second" } }.AsQueryable().Language("first").Count());
      Assert.Equal(1, new[] { null, new LocalizableEntity { Language = "first" }, null, new LocalizableEntity { Language = "second" } }.Language("first").Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ILocalizableExtensions.Culture{T}(IQueryable{T}, CultureInfo)"/></description></item>
    ///     <item><description><see cref="ILocalizableExtensions.Culture{T}(IEnumerable{T}, CultureInfo)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Culture_Info()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<LocalizableEntity>)null).Culture(CultureInfo.InvariantCulture));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<LocalizableEntity>)null).Culture(CultureInfo.InvariantCulture));

      Assert.False(Enumerable.Empty<LocalizableEntity>().AsQueryable().Culture(null).Any());
      Assert.False(Enumerable.Empty<LocalizableEntity>().Culture(null).Any());

      Assert.Equal(1, new[] { new LocalizableEntity { Language = "en" }, new LocalizableEntity { Language = "ru" } }.AsQueryable().Culture(CultureInfo.GetCultureInfo("en")).Count());
      Assert.Equal(1, new[] { null, new LocalizableEntity { Language = "en" }, null, new LocalizableEntity { Language = "ru" } }.Culture(CultureInfo.GetCultureInfo("en")).Count());
    }

    private sealed class LocalizableEntity : ILocalizable
    {
      public string Language { get; set; }
    }
  }
}
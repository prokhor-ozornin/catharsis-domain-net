using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ProfileExtensions"/>.</para>
  /// </summary>
  public sealed class ProfileExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ProfileExtensions.Type(IQueryable{Profile}, string)"/></description></item>
    ///     <item><description><see cref="ProfileExtensions.Type(IEnumerable{Profile}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void WithType_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Profile>) null).Type("type"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Profile>)null).Type("type"));
      
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Profile>().AsQueryable().Type(null));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Profile>().Type(null));

      Assert.Equal(1, new[] { new Profile { Type = "first" }, new Profile { Type = "second" } }.AsQueryable().Type("first").Count());
      Assert.Equal(1, new[] { null, new Profile { Type = "first" }, null, new Profile { Type = "second" } }.Type("first").Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ProfileExtensions.Username(IQueryable{Profile}, string)"/></description></item>
    ///     <item><description><see cref="ProfileExtensions.Username(IEnumerable{Profile}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void WithUsername_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Profile>) null).Username("username"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Profile>)null).Username("username"));
      
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Profile>().AsQueryable().Username(null));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Profile>().Username(null));

      Assert.Equal(1, new[] { new Profile { Id = 1, Username = "first" }, new Profile { Id = 1, Username = "second" } }.AsQueryable().Username("first").Id);
      Assert.Equal(1, new[] { null, new Profile { Id = 1, Username = "username" }, null, new Profile { Id = 2, Username = "username" } }.Username("username").Id);
    }
  }
}
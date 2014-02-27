using System;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Faq"/>.</para>
  /// </summary>
  public sealed class FaqTests : EntityUnitTests<Faq>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Faq()"/>
    ///   <seealso cref="Faq(string, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var faq = new Faq();
      Assert.False(faq.Comments.Any());
      Assert.True(faq.DateCreated >= DateTime.MinValue && faq.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, faq.Id);
      Assert.Null(faq.Language);
      Assert.True(faq.LastUpdated >= DateTime.MinValue && faq.LastUpdated <= DateTime.UtcNow);
      Assert.Null(faq.Name);
      Assert.False(faq.Tags.Any());
      Assert.Null(faq.Text);
      Assert.Equal(0, faq.Version);

      Assert.Throws<ArgumentNullException>(() => new Faq(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Faq("name", null));
      Assert.Throws<ArgumentException>(() => new Faq(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Faq("name", string.Empty));
      faq = new Faq("name", "text");
      Assert.False(faq.Comments.Any());
      Assert.True(faq.DateCreated >= DateTime.MinValue && faq.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, faq.Id);
      Assert.Null(faq.Language);
      Assert.True(faq.LastUpdated >= DateTime.MinValue && faq.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", faq.Name);
      Assert.False(faq.Tags.Any());
      Assert.Equal("text", faq.Text);
      Assert.Equal(0, faq.Version);
    }
  }
}
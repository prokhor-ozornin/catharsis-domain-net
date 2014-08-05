using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Notification"/>.</para>
  /// </summary>
  public sealed class NotificationTests : EntityUnitTests<Notification>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Language", "Text", "Type");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var notification = new Notification();
      this.TestJson(notification, new { Id = 0, Type = 0 });

      notification = new Notification("text");
      this.TestJson(notification, new { Id = 0, Text = "text", Type = 0});

      notification = new Notification("text", 1)
      {
        Id = 1,
        Language = "language"
      };
      this.TestJson(notification, new { Id = 1, Language = "language", Text = "text", Type = 1 });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var notification = new Notification();
      this.TestXml(notification, new { Id = 0, Type = 0 });

      notification = new Notification("text");
      this.TestXml(notification, new { Id = 0, Text = "text", Type = 0 });

      notification = new Notification("text", 1)
      {
        Id = 1,
        Language = "language"
      };
      this.TestXml(notification, new { Id = 1, Language = "language", Text = "text", Type = 1 });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Notification()"/>
    /// <seealso cref="Notification(string, int)"/>
    [Fact]
    public void Constructors()
    {
      var notification = new Notification();
      Assert.Equal(0, notification.Id);
      Assert.Null(notification.Language);
      Assert.Null(notification.Text);
      Assert.Equal(0, notification.Type);
      Assert.Equal(0, notification.Version);

      Assert.Throws<ArgumentNullException>(() => new Notification { Text = null });
      Assert.Throws<ArgumentException>(() => new Notification { Text = string.Empty });
      notification = new Notification("text", 1);
      Assert.Equal(0, notification.Id);
      Assert.Null(notification.Language);
      Assert.Equal("text", notification.Text);
      Assert.Equal(1, notification.Type);
      Assert.Equal(0, notification.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Notification.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Notification { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Notification.Version"/> property.</para>
    /// </summary>
    [Fact]
    public void Version_Property()
    {
      Assert.Equal(1, new Notification { Version = 1 }.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Notification.Language"/> property.</para>
    /// </summary>
    [Fact]
    public void Language_Property()
    {
      Assert.Equal("language", new Notification { Language = "language" }.Language);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Notification.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Notification { Text = null });
      Assert.Throws<ArgumentException>(() => new Notification { Text = string.Empty });

      Assert.Equal("text", new Notification { Text = "text" }.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Notification.Type"/> property.</para>
    /// </summary>
    [Fact]
    public void Type_Property()
    {
      Assert.Equal(1, new Notification { Type = 1 }.Type);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Notification.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("text", new Notification { Text = "text" }.Text);
    }
  }
}
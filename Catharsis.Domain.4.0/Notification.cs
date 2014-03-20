using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents short text information.</para>
  /// </summary>
  [Description("Represents short text information")]
  public partial class Notification : IEquatable<Notification>, IEntity, ILocalizable, ITypeable
  {
    private string text;

    /// <summary>
    ///   <para>Unique identifier of notification.</para>
    /// </summary>
    [Description("Unique identifier of notification")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current notification instance.</para>
    /// </summary>
    [Description("Version number of current notification instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>ISO language code of notifications's text.</para>
    /// </summary>
    [Description("ISO language code of notifications's text")]
    public virtual string Language { get; set; }

    /// <summary>
    ///   <para>Text of notification.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Text of notification")]
    public virtual string Text
    {
      get { return this.text; }
      set
      {
        Assertion.NotEmpty(value);

        this.text = value;
      }
    }

    /// <summary>
    ///   <para>Type of notification.</para>
    /// </summary>
    [Description("Type of notification")]
    public virtual int Type { get; set; }

    /// <summary>
    ///   <para>Creates new notification.</para>
    /// </summary>
    public Notification()
    {
    }

    /// <summary>
    ///   <para>Creates new notification.</para>
    /// </summary>
    /// <param name="text">Text of notification.</param>
    /// <param name="type">Type of notification.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public Notification(string text, int type = 0)
    {
      this.Text = text;
      this.Type = type;
    }

    /// <summary>
    ///   <para>Determines whether two notifications instances are equal.</para>
    /// </summary>
    /// <param name="other">The notification to compare with the current one.</param>
    /// <returns><c>true</c> if specified notification is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Notification other)
    {
      return this.Equality(other, notification => notification.Language, notification => notification.Text, notification => notification.Type);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Notification);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(notification => notification.Language, notification => notification.Text, notification => notification.Type);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current notification.</para>
    /// </summary>
    /// <returns>A string that represents the current notification.</returns>
    public override string ToString()
    {
      return this.Text;
    }
  }
}
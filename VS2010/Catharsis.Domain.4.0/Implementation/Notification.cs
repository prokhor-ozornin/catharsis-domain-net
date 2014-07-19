using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents short text information.</para>
  /// </summary>
  [Description("Represents short text information")]
  public partial class Notification : Entity, ILocalizable, ITypeable
  {
    private string text;

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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Notification"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Notification"/>.</returns>
    public override string ToString()
    {
      return this.Text;
    }
  }
}
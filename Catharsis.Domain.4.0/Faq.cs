using System;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents Frequently Asked Question.</para>
  /// </summary>
  public partial class Faq : Item
  {
    /// <summary>
    ///   <para>Creates new F.A.Q.</para>
    /// </summary>
    public Faq()
    {
    }

    /// <summary>
    ///   <para>Creates new F.A.Q.</para>
    /// </summary>
    /// <param name="name">Name of F.A.Q.</param>
    /// <param name="text">F.A.Q.'s question text.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public Faq(string name, string text) : base(name, text)
    {
      Assertion.NotEmpty(text);
    }
  }
}
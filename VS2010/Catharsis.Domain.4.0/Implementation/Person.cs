using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a human person/user.</para>
  /// </summary>
  [Description("Represents a human person/user")]
  public partial class Person : Entity, IComparable<Person>
  {
    private string nameFirst;
    private string nameLast;

    /// <summary>
    ///   <para>Day of person's birth date.</para>
    /// </summary>
    [Description("Day of person's birth date")]
    public virtual byte? BirthDay { get; set; }
    
    /// <summary>
    ///   <para>Month of person' birth date.</para>
    /// </summary>
    [Description("Month of person' birth date")]
    public virtual byte? BirthMonth { get; set; }
    
    /// <summary>
    ///   <para>Year of person's birth date.</para>
    /// </summary>
    [Description("Year of person's birth date")]
    public virtual short? BirthYear { get; set; }
    
    /// <summary>
    ///   <para>Day of person's death date.</para>
    /// </summary>
    [Description("Day of person's death date")]
    public virtual byte? DeathDay { get; set; }
    
    /// <summary>
    ///   <para>Month of person's death date.</para>
    /// </summary>
    [Description("Month of person's death date")]
    public virtual byte? DeathMonth { get; set; }
    
    /// <summary>
    ///   <para>Year of person's death date.</para>
    /// </summary>
    [Description("Year of person's death date")]
    public virtual short? DeathYear { get; set; }
    
    /// <summary>
    ///   <para>Description/biography of person.</para>
    /// </summary>
    [Description("Description/biography of person")]
    public virtual string Description { get; set; }
    
    /// <summary>
    ///   <para>URI of person's photo/avatar image.</para>
    /// </summary>
    [Description("URI of person's photo/avatar image")]
    public virtual string Image { get; set; }
    
    /// <summary>
    ///   <para>First name of person.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("First name of person")]
    public virtual string NameFirst
    {
      get { return this.nameFirst; }
      set
      {
        Assertion.NotEmpty(value);

        this.nameFirst = value;
      }
    }
    
    /// <summary>
    ///   <para>Last name of person.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Last name of person")]
    public virtual string NameLast
    {
      get { return this.nameLast; }
      set
      {
        Assertion.NotEmpty(value);

        this.nameLast = value;
      }
    }
    
    /// <summary>
    ///   <para>Middle name of person.</para>
    /// </summary>
    [Description("Middle name of person")]
    public virtual string NameMiddle { get; set; }

    /// <summary>
    ///   <para>Creates new person.</para>
    /// </summary>
    public Person()
    {
    }

    /// <summary>
    ///   <para>Creates new person.</para>
    /// </summary>
    /// <param name="nameFirst">First name of person.</param>
    /// <param name="nameLast">Last name of person.</param>
    /// <param name="nameMiddle">Middle name of person.</param>
    /// <param name="description">Description/biography of person.</param>
    /// <param name="image">URI of person's photo/avatar image.</param>
    /// <param name="birthDay">Day of person's birth date.</param>
    /// <param name="birthMonth">Month of person's birth date.</param>
    /// <param name="birthYear">Year of person's birth date.</param>
    /// <param name="deathDay">Day of person's death date.</param>
    /// <param name="deathMonth">Month of person's death date.</param>
    /// <param name="deathYear">Year of person's death date.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="nameFirst"/> or <paramref name="nameLast"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="nameFirst"/> or <paramref name="nameLast"/> is <see cref="string.Empty"/> string.</exception>
    public Person(string nameFirst, string nameLast, string nameMiddle = null, string description = null, string image = null, byte? birthDay = null, byte? birthMonth = null, short? birthYear = null, byte? deathDay = null, byte? deathMonth = null, short? deathYear = null)
    {
      this.NameFirst = nameFirst;
      this.NameLast = nameLast;
      this.NameMiddle = nameMiddle;
      this.Description = description;
      this.Image = image;
      this.BirthDay = birthDay;
      this.BirthMonth = birthMonth;
      this.BirthYear = birthYear;
      this.DeathDay = deathDay;
      this.DeathMonth = deathMonth;
      this.DeathYear = deathYear;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Person"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Person"/> to compare with this instance.</param>
    public virtual int CompareTo(Person other)
    {
      return this.NameLast.CompareTo(other.NameLast, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Person"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Person"/>.</returns>
    public override string ToString()
    {
      return this.NameMiddle.IsEmpty() ? "{0} {1}".FormatSelf(this.NameLast, this.NameFirst) : "{0} {1} {2}".FormatSelf(this.NameLast, this.NameFirst, this.NameMiddle);
    }
  }
}
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a human person/user.</para>
  /// </summary>
  [Description("Represents a human person/user")]
  public partial class Person : IComparable<Person>, IEquatable<Person>, IEntity
  {
    private string nameFirst;
    private string nameLast;

    /// <summary>
    ///   <para>Unique identifier of person.</para>
    /// </summary>
    [Description("Unique identifier of person")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current person instance.</para>
    /// </summary>
    [Description("Version number of current person instance")]
    [XmlIgnore]
    public virtual long Version { get; set; }

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
    ///   <para>Compares the current person with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Person"/> to compare with this instance.</param>
    public virtual int CompareTo(Person person)
    {
      return this.NameLast.Compare(person.NameLast, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two items instances are equal.</para>
    /// </summary>
    /// <param name="other">The item to compare with the current one.</param>
    /// <returns><c>true</c> if specified item is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Person other)
    {
      return this.Equality(other, person => person.BirthDay, person => person.BirthMonth, person => person.BirthYear, person => person.DeathDay, person => person.DeathMonth, person => person.DeathYear, person => person.NameFirst, person => person.NameLast, person => person.NameMiddle);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Person);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(person => person.BirthDay, person => person.BirthMonth, person => person.BirthYear, person => person.DeathDay, person => person.DeathMonth, person => person.DeathYear, person => person.NameFirst, person => person.NameLast, person => person.NameMiddle);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current person.</para>
    /// </summary>
    /// <returns>A string that represents the current person.</returns>
    public override string ToString()
    {
      return this.NameMiddle.IsEmpty() ? "{0} {1}".FormatValue(this.NameLast, this.NameFirst) : "{0} {1} {2}".FormatValue(this.NameLast, this.NameFirst, this.NameMiddle);
    }
  }
}
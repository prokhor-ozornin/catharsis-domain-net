namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a human person/user.</para>
  /// </summary>
  public partial interface IPerson : IEntity
  {
    /// <summary>
    ///   <para>Day of person's birth date.</para>
    /// </summary>
    byte? BirthDay { get; }

    /// <summary>
    ///   <para>Month of person' birth date.</para>
    /// </summary>
    byte? BirthMonth { get; }

    /// <summary>
    ///   <para>Year of person's birth date.</para>
    /// </summary>
    short? BirthYear { get; }

    /// <summary>
    ///   <para>Day of person's death date.</para>
    /// </summary>
    byte? DeathDay { get; }

    /// <summary>
    ///   <para>Month of person's death date.</para>
    /// </summary>
    byte? DeathMonth { get; }

    /// <summary>
    ///   <para>Year of person's death date.</para>
    /// </summary>
    short? DeathYear { get; }

    /// <summary>
    ///   <para>Description/biography of person.</para>
    /// </summary>
    string Description { get; }

    /// <summary>
    ///   <para>URI of person's photo/avatar image.</para>
    /// </summary>
    string Image { get; }

    /// <summary>
    ///   <para>First name of person.</para>
    /// </summary>
    string NameFirst { get; }

    /// <summary>
    ///   <para>Last name of person.</para>
    /// </summary>
    string NameLast { get; }

    /// <summary>
    ///   <para>Middle name of person.</para>
    /// </summary>
    string NameMiddle { get; }
  }
}
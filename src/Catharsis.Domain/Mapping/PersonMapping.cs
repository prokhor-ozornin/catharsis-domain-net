namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Person"/> entity.</para>
/// </summary>
public sealed class PersonMapping : EntityMapping<Person>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public PersonMapping()
  {
    Table("person");
    CheckConstraint("birth_date <= death_date");
    Map(person => person.FirstName).Column("first_name").Not.Nullable().Index("ix-person-first_name");
    Map(person => person.LastName).Column("last_name").Not.Nullable().Index("ix-person-last_name");
    Map(person => person.MiddleName).Column("middle_name").Index("ix-person-middle_name");
    Map(person => person.BirthDate).Column("birth_date").Index("ix-person-birth_date");
    Map(person => person.DeathDate).Column("death_date").Index("ix-person-death_date");
  }
}
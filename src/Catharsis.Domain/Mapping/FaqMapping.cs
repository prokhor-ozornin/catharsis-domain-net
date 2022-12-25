namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Faq"/> entity.</para>
/// </summary>
public sealed class FaqMapping : EntityMapping<Faq>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public FaqMapping()
  {
    Table("faq");
    Map(faq => faq.Question).Column("question").Not.Nullable().Length(4000);
    Map(faq => faq.Answer).Column("answer").Not.Nullable().Length(4000);
  }
}
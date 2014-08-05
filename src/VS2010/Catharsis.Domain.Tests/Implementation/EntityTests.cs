using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Entity"/>.</para>
  /// </summary>
  public sealed class EntityTests : EntityUnitTests<TestEntity>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Id", "Version");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var entity = new TestEntity();
      this.TestJson(entity, new { Id = 0 });

      entity = new TestEntity { Id = 1, Version = 2 };
      this.TestJson(entity, new { Id = 1 });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var entity = new TestEntity();
      this.TestXml(entity, new { Id = 0 });

      entity = new TestEntity { Id = 1, Version = 2 };
      this.TestXml(entity, new { Id = 1 });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Entity()"/>
    [Fact]
    public void Constructors()
    {
      var entity = new TestEntity();
      Assert.Equal(0, entity.Id);
      Assert.Equal(0, entity.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Entity.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new TestEntity { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Entity.Version"/> property.</para>
    /// </summary>
    [Fact]
    public void Version_Property()
    {
      Assert.Equal(1, new TestEntity { Version = 1 }.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Entity.CompareTo(IEntity)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Entity.Equals(IEntity)"/></description></item>
    ///     <item><description><see cref="Entity.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("Catharsis.Domain.TestEntity#1", new TestEntity { Id = 1 }.ToString());
    }
  }

  public sealed class TestEntity : Entity
  {
  }
}
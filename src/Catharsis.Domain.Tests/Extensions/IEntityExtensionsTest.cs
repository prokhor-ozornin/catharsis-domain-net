using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for interface <see cref="IEntity"/>.</para>
/// </summary>
public sealed class IEntityExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.CreatedOn{T}(IQueryable{T}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void CreatedOn_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<IEntity>) null).CreatedOn()).ThrowExactly<ArgumentNullException>();

    var entities = new[] {new Entity {CreatedOn = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Entity {CreatedOn = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0,TimeSpan.Zero)}}.AsQueryable();
    entities.CreatedOn().Should().HaveCount(2);
    entities.CreatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.CreatedOn(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.CreatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.CreatedOn(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.CreatedOn(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.CreatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.CreatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.CreatedOn{T}(IEnumerable{T?}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void CreatedOn_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<IEntity>) null).CreatedOn()).ThrowExactly<ArgumentNullException>();

    var entities = new[] {null, new Entity(), new Entity {CreatedOn = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Entity {CreatedOn = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    entities.CreatedOn().Should().HaveCount(3);
    entities.CreatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.CreatedOn(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.CreatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.CreatedOn(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.CreatedOn(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.CreatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.CreatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.Id{T}(IQueryable{T}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Id_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<IEntity>) null).Id(1)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<Entity>().AsQueryable().Id(1).Should().BeNull();

    new[] {new Entity {Id = 1}, new Entity {Id = 2}}.AsQueryable().Id(1).Id.Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.Id{T}(IEnumerable{T?}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Id_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<IEntity>) null).Id(1)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<Entity>().Id(1).Should().BeNull();

    new[] { null, new Entity { Id = 1 }, null, new Entity { Id = 2 } }.Id(1).Id.Should().Be(1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.Random{T}(IQueryable{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Random_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<IEntity>) null).Random()).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IEntity>().AsQueryable().Random().Should().BeNull();

    var first = new Entity {Id = 1};
    var second = new Entity {Id = 2};
    var entities = new IEntity[] {first, second}.AsQueryable();
    new IEntity[] {first}.Random().Should().BeSameAs(first);
    entities.Should().Contain(entities.Random());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.Random{T}(IEnumerable{T?})"/> method.</para>
  /// </summary>
  [Fact]
  public void Random_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<IEntity>) null).Random()).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IEntity>().Random().Should().BeNull();

    var first = new Entity {Id = 1};
    var second = new Entity {Id = 2};
    var entities = new IEntity[] {first, second};
    new IEntity[] {first}.Random().Should().BeSameAs(first);
    entities.Should().Contain(entities.Random());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.UpdatedOn{T}(IQueryable{T}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void UpdatedOn_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<IEntity>) null).UpdatedOn()).ThrowExactly<ArgumentNullException>();

    var entities = new[] {new Entity {UpdatedOn = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Entity {UpdatedOn = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}}.AsQueryable();
    entities.UpdatedOn().Should().HaveCount(2);
    entities.UpdatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.UpdatedOn(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.UpdatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.UpdatedOn(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.UpdatedOn(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.UpdatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.UpdatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEntityExtensions.UpdatedOn{T}(IEnumerable{T?}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void UpdatedOn_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<IEntity>) null).UpdatedOn()).ThrowExactly<ArgumentNullException>();

    var entities = new[] {null, new Entity(), new Entity {UpdatedOn = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Entity {UpdatedOn = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    entities.UpdatedOn().Should().HaveCount(3);
    entities.UpdatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.UpdatedOn(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.UpdatedOn(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.UpdatedOn(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entities.UpdatedOn(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entities.UpdatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entities.UpdatedOn(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  private sealed class Entity : IEntity
  {
    public long? Id { get; set; }

    public Guid? Uuid { get; set; }

    public long? Version { get; set; }

    public DateTimeOffset? CreatedOn { get; set; }

    public DateTimeOffset? UpdatedOn { get; set; }
  }
}
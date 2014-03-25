using System;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="ENTITY"></typeparam>
  public abstract class EntityUnitTests<ENTITY> where ENTITY : IEntity
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    [Fact]
    public virtual void Attributes()
    {
      Assert.False(typeof(ENTITY).Description().IsEmpty());
      this.TestDescription("Id", "Version");
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Id = 1);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    [Fact]
    public void Version_Property()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Version = 1);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="PROPERTY"></typeparam>
    /// <param name="property"></param>
    /// <param name="lower"></param>
    /// <param name="greater"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="property"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="property"/> is <see cref="string.Empty"/> string.</exception>
    protected void TestCompareTo<PROPERTY>(string property, PROPERTY lower, PROPERTY greater)
    {
      Assertion.NotEmpty(property);

      var first = typeof(ENTITY).NewInstance().To<IComparable<ENTITY>>();
      var second = typeof(ENTITY).NewInstance().To<ENTITY>();

      first.Property(property, lower);
      second.Property(property, lower);

      Assert.Equal(0, first.CompareTo(second));
      second.Property(property, greater);
      Assert.True(first.CompareTo(second) < 0);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="PROPERTY"></typeparam>
    /// <param name="property"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="property"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="property"/> is <see cref="string.Empty"/> string.</exception>
    protected void TestEquality<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue)
    {
      Assertion.NotEmpty(property);

      var entity = typeof(ENTITY).NewInstance();

      Assert.False(entity.Equals(null));
      Assert.True(entity.Equals(entity));
      Assert.True(entity.Equals(typeof(ENTITY).NewInstance()));
      
      Assert.True(typeof(ENTITY).NewInstance().Property(property, oldValue).Equals(typeof(ENTITY).NewInstance().Property(property, oldValue)));
      Assert.False(typeof(ENTITY).NewInstance().Property(property, oldValue).Equals(typeof(ENTITY).NewInstance().Property(property, newValue)));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="PROPERTY"></typeparam>
    /// <param name="property"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="property"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="property"/> is <see cref="string.Empty"/> string.</exception>
    protected void TestHashCode<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue)
    {
      Assertion.NotEmpty(property);

      var entity = typeof(ENTITY).NewInstance();

      Assert.Equal(entity.GetHashCode(), entity.GetHashCode());
      Assert.Equal(typeof(ENTITY).NewInstance().GetHashCode(), entity.GetHashCode());

      Assert.Equal(typeof(ENTITY).NewInstance().Property(property, oldValue).GetHashCode(), typeof(ENTITY).NewInstance().Property(property, oldValue).GetHashCode());
      Assert.NotEqual(typeof(ENTITY).NewInstance().Property(property, oldValue).GetHashCode(), typeof(ENTITY).NewInstance().Property(property, newValue).GetHashCode());
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="properties"></param>
    protected void TestDescription(params string[] properties)
    {
      properties.Each(property => Assert.False(typeof(ENTITY).AnyProperty(property).Description().IsEmpty()));
    }
  }
}
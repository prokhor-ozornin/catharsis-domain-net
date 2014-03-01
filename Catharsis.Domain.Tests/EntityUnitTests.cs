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
    public void BaseAttributes()
    {
      this.TestDescription("Id", "Version");
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    [Fact]
    public void TestIdProperty()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Id = 1);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    [Fact]
    public void TestVersionProperty()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Version = 1);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="COMPARABLE"></typeparam>
    /// <typeparam name="PROPERTY"></typeparam>
    /// <param name="property"></param>
    /// <param name="lower"></param>
    /// <param name="greater"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="property"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="property"/> is <see cref="string.Empty"/> string.</exception>
    protected void TestCompareTo<COMPARABLE, PROPERTY>(string property, PROPERTY lower, PROPERTY greater) where COMPARABLE : ENTITY, IComparable<COMPARABLE>
    {
      Assertion.NotEmpty(property);

      var first = typeof(COMPARABLE).NewInstance().To<COMPARABLE>();
      var second = typeof(COMPARABLE).NewInstance().To<COMPARABLE>();

      first.SetProperty(property, lower);
      second.SetProperty(property, lower);

      Assert.Equal(0, first.CompareTo(second));
      second.SetProperty(property, greater);
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
      
      Assert.True(typeof(ENTITY).NewInstance().SetProperty(property, oldValue).Equals(typeof(ENTITY).NewInstance().SetProperty(property, oldValue)));
      Assert.False(typeof(ENTITY).NewInstance().SetProperty(property, oldValue).Equals(typeof(ENTITY).NewInstance().SetProperty(property, newValue)));
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

      Assert.Equal(typeof(ENTITY).NewInstance().SetProperty(property, oldValue).GetHashCode(), typeof(ENTITY).NewInstance().SetProperty(property, oldValue).GetHashCode());
      Assert.NotEqual(typeof(ENTITY).NewInstance().SetProperty(property, oldValue).GetHashCode(), typeof(ENTITY).NewInstance().SetProperty(property, newValue).GetHashCode());
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
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
    [Fact]
    public void TestIdProperty()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Id = 1);
    }

    [Fact]
    public void TestVersionProperty()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Version = 1);
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
  }
}
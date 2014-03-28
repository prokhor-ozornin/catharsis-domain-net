using System;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  public abstract class EntityUnitTests<ENTITY> where ENTITY : IEntity
  {
    [Fact]
    public virtual void Attributes()
    {
      Assert.False(typeof(ENTITY).Description().IsEmpty());
      this.TestDescription("Id", "Version");
    }

    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Id = 1);
    }

    [Fact]
    public void Version_Property()
    {
      Assert.Equal(1, typeof(ENTITY).NewInstance().To<ENTITY>().Version = 1);
    }

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

    protected void TestHashCode<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue)
    {
      Assertion.NotEmpty(property);

      var entity = typeof(ENTITY).NewInstance();

      Assert.Equal(entity.GetHashCode(), entity.GetHashCode());
      Assert.Equal(typeof(ENTITY).NewInstance().GetHashCode(), entity.GetHashCode());

      Assert.Equal(typeof(ENTITY).NewInstance().Property(property, oldValue).GetHashCode(), typeof(ENTITY).NewInstance().Property(property, oldValue).GetHashCode());
      Assert.NotEqual(typeof(ENTITY).NewInstance().Property(property, oldValue).GetHashCode(), typeof(ENTITY).NewInstance().Property(property, newValue).GetHashCode());
    }

    protected void TestDescription(params string[] properties)
    {
      properties.Each(property => Assert.False(typeof(ENTITY).AnyProperty(property).Description().IsEmpty()));
    }

    protected void TestXml(ENTITY entity, string xml, params Type[] types)
    {
      Assertion.NotNull(entity);
      Assertion.NotEmpty(xml);

      Assert.Equal(@"<?xml version=""1.0"" encoding=""utf-16""?><{0} xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">{1}</{0}>".FormatSelf(typeof(ENTITY).Name, xml), entity.Xml(types));
    }
  }
}
using System;
using System.Globalization;
using System.Linq;
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

    protected void TestJson(ENTITY entity, object attributes)
    {
      Assertion.NotNull(entity);

      var json = attributes.GetType().GetProperties().Select(property =>
      {
        var value = property.GetValue(attributes, null);
        if (value is bool)
        {
          value = value.ToString().ToLowerInvariant();
        }
        else if (value is DateTime)
        {
          value = @"""{0}""".FormatSelf(value.To<DateTime>().ISO8601());
        }
        else if (value.GetType().IsPrimitive)
        {
          value = string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }
        else if (value is string)
        {
          value = @"""{0}""".FormatSelf(value);
        }
        else
        {
          var jsonValue = value.Json();
          value = jsonValue.Substring(0, jsonValue.Length);
        }
        return @"""{0}"":{1}".FormatSelf(property.Name, value);
      }).Join(",");

      Assert.Equal(attributes == null ? "{}" : @"{{{0}}}".FormatSelf(json), entity.Json());
    }

    protected void TestXml(ENTITY entity, object attributes)
    {
      Assertion.NotNull(entity);

      var tags = attributes.GetType().GetProperties().Select(property =>
      {
        var value = property.GetValue(attributes, null);

        if (value is bool)
        {
          value = value.ToString().ToLowerInvariant();
        }
        else if (value is DateTime)
        {
          value = value.To<DateTime>().AsXml();
        }

        return string.Format(CultureInfo.InvariantCulture, "<{0}>{1}</{0}>", property.Name, value);
      });

      var xml = entity.Xml();
      Assert.True(xml.Contains(@"<?xml version=""1.0"" encoding=""utf-16""?>"));
      if (attributes == null)
      {
        Assert.True(xml.Contains(@"<{0} xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" />".FormatSelf(typeof(ENTITY).Name)));
      }
      else
      {
        Assert.True(xml.Contains(@"<{0} xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">".FormatSelf(typeof(ENTITY).Name)));
        Assert.True(xml.Contains("</{0}>".FormatSelf(typeof(ENTITY).Name)));
        foreach (var tag in tags)
        {
          Assert.True(xml.Contains(tag));
        }
      }
    }
  }
}
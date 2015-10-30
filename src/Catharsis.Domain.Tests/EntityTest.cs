using Catharsis.Commons;
using System;
using System.ComponentModel;
using Xunit;

namespace Catharsis.Domain
{
  public abstract class EntityTest<T> where T : class, new()
  {
    protected readonly T fixture = new T();

    [Fact]
    public void attributes()
    {
      Assert.NotNull(typeof(T).Attribute<SerializableAttribute>());
      Assert.NotNull(typeof(T).Attribute<DescriptionAttribute>());
    }

    protected void test_compare_to<PROPERTY>(string property, PROPERTY lower, PROPERTY greater)
    {
      Assertion.NotEmpty(property);

      var first = new T().To<IComparable<T>>();
      var second = new T().To<T>();
      second.Properties(first);

      first.Property(property, lower);
      second.Property(property, lower);
      Assert.Equal(0, first.CompareTo(second));
      second.Property(property, greater);
      Assert.True(first.CompareTo(second) < 0);
    }

    protected void test_equals_and_hash_code<PROPERTY>(string property, PROPERTY oldValue, PROPERTY newValue)
    {
      Assertion.NotEmpty(property);

      var first = new T();
      var second = new T();

      second.Properties(first);
      Assert.False(first.Equals(null));
      Assert.True(first.Equals(first));
      Assert.True(first.Equals(second));
      Assert.True(first.Property(property, oldValue).Equals(second.Property(property, oldValue)));
      Assert.False(first.Property(property, oldValue).Equals(second.Property(property, newValue)));

      second.Properties(first);
      Assert.Equal(first.GetHashCode(), first.GetHashCode());
      Assert.Equal(first.GetHashCode(), second.GetHashCode());
      Assert.Equal(first.Property(property, oldValue).GetHashCode(), second.Property(property, oldValue).GetHashCode());
      Assert.NotEqual(first.Property(property, oldValue).GetHashCode(), second.Property(property, newValue).GetHashCode());
    }
  }
}
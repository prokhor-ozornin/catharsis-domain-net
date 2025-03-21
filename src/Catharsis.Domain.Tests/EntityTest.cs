using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace Catharsis.Domain.Tests;

public abstract class EntityTest<T> : UnitTest where T : class, new()
{
  protected T Entity { get; } = new();

  [Fact]
  public void Type()
  {
    typeof(T).Should()
             .BeDerivedFrom<Entity>()
             .And
             .HaveDefaultConstructor();
  }

  [Fact]
  public void Attributes()
  {
    typeof(T).Should()
             .BeDecoratedWith<DescriptionAttribute>()
             .And
             .BeDecoratedWith<DataContractAttribute>();
  }

  [Fact]
  public void Properties()
  {
    typeof(T).Properties().ThatArePublicOrInternal.Should()
             .BeVirtual()
             .And
             .BeWritable()
             .And
             .BeDecoratedWith<DescriptionAttribute>()
             .And
             .BeDecoratedWith<DataMemberAttribute>();
  }

  [Fact]
  public void Serialization()
  {
    Entity.Should()
          //.BeBinarySerializable()
          //.And
          .BeXmlSerializable()
          .And
          .BeDataContractSerializable()
          .And
          .BeJsonSerializable();
  }

  protected void TestCompareTo<TProperty>(string property, TProperty lower, TProperty greater, Func<T> constructor = null) => TestCompareTo<T, TProperty>(property, lower, greater, constructor);

  protected void TestEquality<TProperty>(string property, TProperty oldValue, TProperty newValue, Func<T> constructor = null) => TestEquality<T, TProperty>(property, oldValue, newValue, constructor);

  protected void TestHashCode<TProperty>(string property, TProperty oldValue, TProperty newValue, Func<T> constructor = null) => TestHashCode<T, TProperty>(property, oldValue, newValue, constructor);
}
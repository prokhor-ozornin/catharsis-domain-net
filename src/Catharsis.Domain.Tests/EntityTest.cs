using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Json;
using Xunit;

namespace Catharsis.Domain.Tests;

public abstract class EntityTest<T> : ClassTest<T> where T : class, new()
{
  protected readonly T entity = new();

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
    entity.Should()
          .BeBinarySerializable()
          .And
          .BeXmlSerializable()
          .And
          .BeDataContractSerializable()
          .And
          .BeJsonSerializable();
  }
}
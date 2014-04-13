using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Custom JSON converter for named business entities which serializes only their respective identifiers (<see cref="IEntity.Id"/>) and names (<see cref="INameable.Name"/>) properties.</para>
  /// </summary>
  /// <typeparam name="ENTITY">Type of business entity.</typeparam>
  public class JsonNameableEntityConverter<ENTITY> : JsonEntityConverter<ENTITY> where ENTITY : IEntity, INameable
  {
    /// <summary>
    ///   <para>Writes the JSON representation of the object.</para>
    /// </summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var entity = value.To<ENTITY>();

      writer.WriteStartObject();

      writer.WritePropertyName("Id");
      writer.WriteValue(entity.Id);

      writer.WritePropertyName("Name");
      writer.WriteValue(entity.Name);

      writer.WriteEndObject();
    }
  }
}
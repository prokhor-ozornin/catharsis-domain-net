using System;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Custom JSON converter for business entities which serializes only their respective identifiers (<see cref="IEntity.Id"/>).</para>
  /// </summary>
  /// <typeparam name="ENTITY">Type of business entity.</typeparam>
  public class JsonEntityConverter<ENTITY> : JsonConverter where ENTITY : IEntity
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

      writer.WriteEndObject();
    }

    /// <summary>
    ///   <para>Reads the JSON representation of the object.</para>
    /// </summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>The object value.</returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      return serializer.Deserialize<ENTITY>(reader);
    }

    /// <summary>
    ///   <para>Determines whether this instance can convert the specified object type.</para>
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>
    /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvert(Type objectType)
    {
      return objectType.IsAssignableFrom(typeof(ENTITY));
    }
  }
}
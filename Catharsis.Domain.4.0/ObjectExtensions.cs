using System;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="object"/>.</para>
  /// </summary>
  /// <seealso cref="object"/>
  public static class ObjectExtensions
  {
    private static JsonSerializerSettings jsonSerializerSettings;

    /// <summary>
    ///   <para>Default JSON serializer settings.</para>
    /// </summary>
    public static JsonSerializerSettings JsonSerializerSettings
    {
      get
      {
        return jsonSerializerSettings ?? (jsonSerializerSettings = new JsonSerializerSettings
        {
          ContractResolver = new JsonEntityOrderedContractResolver(),
          Formatting = Formatting.None,
          DateFormatString = "o",
          DateFormatHandling = DateFormatHandling.IsoDateFormat,
          DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
          DefaultValueHandling = DefaultValueHandling.Include,
          NullValueHandling = NullValueHandling.Ignore,
          PreserveReferencesHandling = PreserveReferencesHandling.None,
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
      }
    }

    /// <summary>
    ///   <para>Serializes specified object into JSON string.</para>
    /// </summary>
    /// <param name="subject">Target object to be serialized.</param>
    /// <param name="settings">Serialization settings. If not specified, default settings set will be used.</param>
    /// <returns>JSON serialized version of <paramref name="subject"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="subject"/> is a <c>null</c> reference.</exception>
    /// <seealso cref="JsonConvert"/>
    /// <seealso cref="ObjectExtensions.JsonSerializerSettings"/>
    public static string Json(this object subject, JsonSerializerSettings settings = null)
    {
      Assertion.NotNull(subject);

      return JsonConvert.SerializeObject(subject, settings ?? JsonSerializerSettings);
    }
  }
}
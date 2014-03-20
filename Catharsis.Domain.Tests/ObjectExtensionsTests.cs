using System;
using Catharsis.Commons;
using Newtonsoft.Json;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ObjectExtensions"/>.</para>
  /// </summary>
  public sealed class ObjectExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ObjectExtensions.JsonSerializerSettings"/> property.</para>
    /// </summary>
    [Fact]
    public void JsonSerializerSettings_Property()
    {
      var settings = ObjectExtensions.JsonSerializerSettings;
      Assert.True(settings.ContractResolver.Is<JsonEntityOrderedContractResolver>());
      Assert.Equal(Formatting.None, settings.Formatting);
      Assert.Equal("o", settings.DateFormatString);
      Assert.Equal(DateFormatHandling.IsoDateFormat, settings.DateFormatHandling);
      Assert.Equal(DateTimeZoneHandling.RoundtripKind, settings.DateTimeZoneHandling);
      Assert.Equal(DefaultValueHandling.Include, settings.DefaultValueHandling);
      Assert.Equal(NullValueHandling.Ignore, settings.NullValueHandling);
      Assert.Equal(PreserveReferencesHandling.None, settings.PreserveReferencesHandling);
      Assert.Equal(ReferenceLoopHandling.Ignore, settings.ReferenceLoopHandling);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ObjectExtensions.Json(object, JsonSerializerSettings)"/> method.</para>
    /// </summary>
    [Fact]
    public void Json_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ObjectExtensions.Json(null));

      Assert.Equal("{}", new object().Json());
      Assert.Equal(@"""string""", "string".Json());
      Assert.Equal(@"[""first"",""second""]", new[] { "first", "second" }.Json());

      Assert.Equal(@"{""Id"":0}", new MockJsonObject().Json());

      var subject = new MockJsonObject { Id = 1, PublicProperty = "property", PublicField = "field", Date = DateTime.MinValue };
      Assert.Equal(@"{{""Id"":1,""Date"":""{0}"",""PublicField"":""field"",""PublicProperty"":""property""}}".FormatSelf(DateTime.MinValue.ToString("o")), subject.Json());
      Assert.NotEqual(@"{{""Id"":1,""Date"":""{0}"",""PublicField"":""field"",""PublicProperty"":""property""}}".FormatSelf(DateTime.MinValue.ToString("o")), subject.Json(new JsonSerializerSettings { Formatting = Formatting.Indented }));
    }
  }
}
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
      Assert.Equal(@"{{""Id"":1,""Date"":""{0}"",""PublicField"":""field"",""PublicProperty"":""property""}}".FormatSelf(DateTime.MinValue.ISO8601()), subject.Json());
      Assert.NotEqual(@"{{""Id"":1,""Date"":""{0}"",""PublicField"":""field"",""PublicProperty"":""property""}}".FormatSelf(DateTime.MinValue.ISO8601()), subject.Json(new JsonSerializerSettings { Formatting = Formatting.Indented }));
    }
  }
}
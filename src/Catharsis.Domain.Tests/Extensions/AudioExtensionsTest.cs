using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AudioExtensionsTests
  {
    [Fact]
    public void bitrate_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Audio>) null).Bitrate(0));

      Assert.Equal(1, new[] { new Audio { Bitrate = 32 }, new Audio { Bitrate = 64 } }.AsQueryable().Bitrate(32).Count());
    }

    [Fact]
    public void bitrate_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Audio>)null).Bitrate(0));

      Assert.Equal(1, new[] { null, new Audio(), new Audio { Bitrate = 32 }, new Audio { Bitrate = 64 } }.Bitrate(32).Count());
    }
  }
}
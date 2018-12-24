using System;
using System.Globalization;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class MoneyTest
  {
    [Fact]
    public void constructors()
    {
      var money = new Money();
      Assert.Equal(0, money.Amount);
      Assert.Null(money.Currency);

      money = new Money(1.123);
      Assert.Equal((decimal) 1.123, money.Amount);
      Assert.Equal(new RegionInfo(CultureInfo.CurrentCulture.LCID).ISOCurrencySymbol, money.Currency);

      money = new Money((decimal) 1.123);
      Assert.Equal((decimal) 1.123, money.Amount);
      Assert.Equal(new RegionInfo(CultureInfo.CurrentCulture.LCID).ISOCurrencySymbol, money.Currency);

      Assert.Throws<ArgumentNullException>(() => new Money(1.123, null));
      Assert.Throws<ArgumentException>(() => new Money(1.123, string.Empty));
      money = new Money(1.123, "RUB");
      Assert.Equal((decimal) 1.123, money.Amount);
      Assert.Equal("RUB", money.Currency);

      Assert.Throws<ArgumentNullException>(() => new Money((decimal) 1.123, null));
      Assert.Throws<ArgumentException>(() => new Money((decimal) 1.123, string.Empty));
      money = new Money((decimal) 1.123, "RUB");
      Assert.Equal((decimal) 1.123, money.Amount);
      Assert.Equal("RUB", money.Currency);
    }

    [Fact]
    public void operator_plus()
    {
      Assert.Throws<ArgumentException>(() => new Money(1.1, "RUB") + new Money(1.2, "USD"));

      var first = new Money(1.1, "RUB");
      var second = new Money(2.2, "RUB");
      var result = first + second;
      Assert.Equal((decimal) 3.3, result.Amount);
      Assert.Equal("RUB", result.Currency);
    }

    [Fact]
    public void operator_minus()
    {
      Assert.Throws<ArgumentException>(() => new Money(1.1, "RUB") - new Money(1.2, "USD"));

      var first = new Money(1.1, "RUB");
      var second = new Money(2.2, "RUB");
      var result = first - second;
      Assert.Equal((decimal) -1.1, result.Amount);
      Assert.Equal("RUB", result.Currency);
    }

    [Fact]
    public void operator_multiply()
    {
      Assert.Throws<ArgumentException>(() => new Money(1.1, "RUB") * new Money(1.2, "USD"));

      var first = new Money(1.1, "RUB");
      var second = new Money(2.2, "RUB");
      var result = first * second;
      Assert.Equal((decimal) 2.42, result.Amount);
      Assert.Equal("RUB", result.Currency);
    }

    [Fact]
    public void operator_division()
    {
      Assert.Throws<ArgumentException>(() => new Money(1.1, "RUB") / new Money(1.2, "USD"));

      var first = new Money(1.1, "RUB");
      var second = new Money(2.2, "RUB");
      var result = first / second;
      Assert.Equal((decimal) 0.5, result.Amount);
      Assert.Equal("RUB", result.Currency);
    }

    [Fact]
    public void operator_unary_minus()
    {
      var money = -new Money(1.1, "RUB");
      Assert.Equal((decimal) -1.1, money.Amount);
      Assert.Equal("RUB", money.Currency);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      Assert.Equal(new Money(), new Money());
      Assert.Equal(new Money().GetHashCode(), new Money().GetHashCode());

      Assert.Equal(new Money(1.123), new Money(1.123));
      Assert.Equal(new Money(1.123).GetHashCode(), new Money(1.123).GetHashCode());

      Assert.NotEqual(new Money(1.1), new Money(1.2));
      Assert.NotEqual(new Money(1.1).GetHashCode(), new Money(1.2).GetHashCode());

      Assert.Equal(new Money(1.123, "RUB"), new Money(1.123, "RUB"));
      Assert.Equal(new Money(1.123, "RUB").GetHashCode(), new Money(1.123, "RUB").GetHashCode());

      Assert.NotEqual(new Money(1.123, "RUB"), new Money(1.123, "USD"));
      Assert.NotEqual(new Money(1.123, "RUB").GetHashCode(), new Money(1.123, "USD").GetHashCode());
    }

    [Fact]
    public void to_string()
    {
      Assert.Equal("0", new Money().ToString());
      Assert.Equal($"1.123 {new RegionInfo(CultureInfo.CurrentCulture.LCID).ISOCurrencySymbol}", new Money(1.123).ToString());
      Assert.Equal("1.123 RUB", new Money(1.123, "RUB").ToString());
    }
  }
}
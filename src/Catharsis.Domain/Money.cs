using Catharsis.Commons;
using System;
using System.Globalization;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para></para>
  /// </summary>
#if NET_35
  [Serializable]
#endif
  public struct Money : IEquatable<Money>
  {
    public Money(decimal amount) : this(amount, new RegionInfo(CultureInfo.CurrentCulture.ToString()).ISOCurrencySymbol)
    {
    }

    public Money(double amount) : this(amount, new RegionInfo(CultureInfo.CurrentCulture.ToString()).ISOCurrencySymbol)
    {
    }

    public Money(decimal amount, string currency)
    {
      Assertion.NotEmpty(currency);

      this.Amount = amount;
      this.Currency = currency;
    }

    public Money(double amount, string currency) : this((decimal) amount, currency)
    {
    }

    public decimal Amount { get; }

    public string Currency { get; }

    public static Money operator +(Money first, Money second)
    {
      Assertion.Equal(first.Currency, second.Currency);

      return new Money(first.Amount + second.Amount, first.Currency);
    }

    public static Money operator -(Money first, Money second)
    {
      Assertion.Equal(first.Currency, second.Currency);

      return new Money(first.Amount - second.Amount, first.Currency);
    }

    public static Money operator *(Money first, Money second)
    {
      Assertion.Equal(first.Currency, second.Currency);

      return new Money(first.Amount * second.Amount, first.Currency);
    }

    public static Money operator /(Money first, Money second)
    {
      Assertion.Equal(first.Currency, second.Currency);

      return new Money(first.Amount / second.Amount, first.Currency);
    }

    public static Money operator -(Money money)
    {
      return new Money(-money.Amount, money.Currency);
    }

    public bool Equals(Money other)
    {
      return this.Equality(other, it => it.Amount, it => it.Currency);
    }

    public override bool Equals(object other)
    {
      return this.Equals((Money) other);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Amount, it => it.Currency);
    }

    public override string ToString()
    {
      return $"{this.Amount.ToStringInvariant()} {this.Currency}".Trim();
    }
  }
}
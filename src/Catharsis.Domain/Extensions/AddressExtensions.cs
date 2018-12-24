using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class AddressExtensions
  {
    public static IQueryable<Address> City(this IQueryable<Address> addresses, City city)
    {
      Assertion.NotNull(addresses);

      return city != null ? addresses.Where(it => it.City.Id == city.Id) : addresses.Where(it => it.City == null);
    }

    public static IEnumerable<Address> City(this IEnumerable<Address> addresses, City city)
    {
      Assertion.NotNull(addresses);

      return city != null ? addresses.Where(it => it?.City != null && it.City.Equals(city)) : addresses.Where(it => it != null && it.City == null);
    }

    public static IQueryable<Address> Name(this IQueryable<Address> addresses, string name)
    {
      Assertion.NotNull(addresses);
      Assertion.NotEmpty(name);

      return addresses.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Address> Name(this IEnumerable<Address> addresses, string name)
    {
      Assertion.NotNull(addresses);
      Assertion.NotEmpty(name);

      return addresses.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}
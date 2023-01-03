namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Address"/>.</para>
/// </summary>
/// <seealso cref="Address"/>
public static class AddressExtensions
{
  public static IQueryable<Address> City(this IQueryable<Address> addresses, City city) => city != null ? addresses.Where(address => address.City != null && address.City.Id == city.Id) : addresses.Where(address => address.City == null);

  public static IEnumerable<Address> City(this IEnumerable<Address> addresses, City city) => city != null ? addresses.Where(address => address?.City != null && address.City.Equals(city)) : addresses.Where(address => address is {City: null});

  public static IQueryable<Address> Name(this IQueryable<Address> addresses, string name) => addresses.Where(address => address.Name != null && address.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Address> Name(this IEnumerable<Address> addresses, string name) => addresses.Where(address => address?.Name != null && address.Name.ToLower().StartsWith(name.ToLower()));
}
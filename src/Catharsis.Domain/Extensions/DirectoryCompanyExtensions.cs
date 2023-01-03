namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="DirectoryCompany"/>.</para>
/// </summary>
/// <seealso cref="DirectoryCompany"/>
public static class DirectoryCompanyExtensions
{
  public static IQueryable<DirectoryCompany> Name(this IQueryable<DirectoryCompany> companies, string name) => companies.Where(company => company.ShortName != null && company.Name != null && (company.Name.ToLower().StartsWith(name.ToLower()) || company.ShortName.ToLower().StartsWith(name.ToLower())));

  public static IEnumerable<DirectoryCompany> Name(this IEnumerable<DirectoryCompany> companies, string name) => companies.Where(company => company is {Name: {}, ShortName: {}} && (company.Name.ToLower().StartsWith(name.ToLower()) || company.ShortName.ToLower().StartsWith(name.ToLower())));
}
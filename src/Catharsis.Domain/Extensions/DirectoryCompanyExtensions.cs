using Catharsis.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain.Extensions
{
  public static class DirectoryCompanyExtensions
  {
    public static IQueryable<DirectoryCompany> Name(this IQueryable<DirectoryCompany> companies, string name)
    {
      Assertion.NotNull(companies);
      Assertion.NotEmpty(name);

      name = name.ToLower();
      return companies.Where(it => it.Name.ToLower().StartsWith(name) || it.ShortName.ToLower().StartsWith(name));
    }

    public static IEnumerable<DirectoryCompany> Name(this IEnumerable<DirectoryCompany> companies, string name)
    {
      Assertion.NotNull(companies);
      Assertion.NotEmpty(name);

      name = name.ToLower();
      return companies.Where(it => it?.Name != null && it.ShortName != null && (it.Name.ToLower().StartsWith(name) || it.ShortName.ToLower().StartsWith(name)));
    }
  }
}
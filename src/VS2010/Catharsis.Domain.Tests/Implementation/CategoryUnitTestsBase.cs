using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class CategoryUnitTestsBase<T> : EntityUnitTests<T> where T : Category
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="Category.CompareTo(ICategory)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Category.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", typeof(T).NewInstance().To<T>().Property("Name", "name").ToString());
    }
  }
}
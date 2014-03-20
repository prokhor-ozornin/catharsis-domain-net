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
    ///   <para>Performs testing of <see cref="Category.CompareTo(Category)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Category.Equals(Category)"/></description></item>
    ///     <item><description><see cref="Category.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Name", "first", "second");
      this.TestEquality("Language", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Category.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
      this.TestHashCode("Language", "first", "second");
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
using System.Reflection;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class CategoryUnitTests<T> : EntityUnitTests<T> where T : Category
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var category = typeof(T).NewInstance().To<T>();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Equal(0, category.Version);

      Assert.Throws<TargetInvocationException>(() => typeof(T).NewInstance(null, null));
      Assert.Throws<TargetInvocationException>(() => typeof(T).NewInstance(string.Empty, null));
      category = typeof(T).NewInstance("name", "description").To<T>();
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Category.CompareTo(Category)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      var first = typeof(T).NewInstance().To<T>();
      var second = typeof(T).NewInstance().To<T>();

      first.Name = "first";
      second.Name = "second";
      Assert.True(first.CompareTo(second) < 0);

      first.Name = "name";
      second.Name = "name";
      Assert.Equal(0, first.CompareTo(second));
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
      var category = typeof(T).NewInstance().To<T>();
      category.Name = "name";
      Assert.Equal("name", category.ToString());
    }
  }
}
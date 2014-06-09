using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Person"/>.</para>
  /// </summary>
  public sealed class PersonTests : EntityUnitTests<Person>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("BirthDay", "BirthMonth", "BirthYear", "DeathDay", "DeathMonth", "DeathYear", "Description", "Image", "NameFirst", "NameLast", "NameMiddle");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var person = new Person();
      this.TestJson(person, new { Id = 0 });

      person = new Person("nameFirst", "nameLast");
      this.TestJson(person, new { Id = 0, NameFirst = "nameFirst", NameLast = "nameLast" });

      person = new Person("nameFirst", "nameLast", "nameMiddle", "description", "image", 1, 2, 3, 4, 5, 6)
      {
        Id = 1
      };
      this.TestJson(person, new { Id = 1, BirthDay = 1, BirthMonth = 2, BirthYear = 3, DeathDay = 4, DeathMonth = 5, DeathYear = 6, Description = "description", Image = "image", NameFirst = "nameFirst", NameLast = "nameLast", NameMiddle = "nameMiddle" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var person = new Person();
      this.TestXml(person, new { Id = 0 });

      person = new Person("nameFirst", "nameLast");
      this.TestXml(person, new { Id = 0, NameFirst = "nameFirst", NameLast = "nameLast" });

      person = new Person("nameFirst", "nameLast", "nameMiddle", "description", "image", 1, 2, 3, 4, 5, 6)
      {
        Id = 1
      };
      this.TestXml(person, new { Id = 1, BirthDay = 1, BirthMonth = 2, BirthYear = 3, DeathDay = 4, DeathMonth = 5, DeathYear = 6, Description = "description", Image = "image", NameFirst = "nameFirst", NameLast = "nameLast", NameMiddle = "nameMiddle" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Person()"/>
    /// <seealso cref="Person(string, string, string, string, string, byte?, byte?, short?, byte?, byte?, short?)"/>
    [Fact]
    public void Constructors()
    {
      var person = new Person();
      Assert.Null(person.BirthDay);
      Assert.Null(person.BirthMonth);
      Assert.Null(person.BirthYear);
      Assert.Null(person.DeathDay);
      Assert.Null(person.DeathMonth);
      Assert.Null(person.DeathYear);
      Assert.Null(person.Description);
      Assert.Equal(0, person.Id);
      Assert.Null(person.Image);
      Assert.Null(person.NameFirst);
      Assert.Null(person.NameLast);
      Assert.Null(person.NameMiddle);
      Assert.Equal(0, person.Version);

      Assert.Throws<ArgumentNullException>(() => new Person(null, "nameLast"));
      Assert.Throws<ArgumentNullException>(() => new Person("nameFirst", null));
      Assert.Throws<ArgumentException>(() => new Person(string.Empty, "nameLast"));
      Assert.Throws<ArgumentException>(() => new Person("nameFirst", string.Empty));
      person = new Person("nameFirst", "nameLast", "nameMiddle", "description", "image", 1, 2, 2000, 3, 4, 2030);
      Assert.Equal((byte) 1, person.BirthDay);
      Assert.Equal((byte) 2, person.BirthMonth);
      Assert.Equal((short) 2000, person.BirthYear);
      Assert.Equal((byte) 3, person.DeathDay);
      Assert.Equal((byte) 4, person.DeathMonth);
      Assert.Equal((short) 2030, person.DeathYear);
      Assert.Equal("description", person.Description);
      Assert.Equal(0, person.Id);
      Assert.NotNull(person.Image);
      Assert.Equal("nameFirst", person.NameFirst);
      Assert.Equal("nameLast", person.NameLast);
      Assert.Equal("nameMiddle", person.NameMiddle);
      Assert.Equal(0, person.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.BirthDay"/> property.</para>
    /// </summary>
    [Fact]
    public void BirthDay_Property()
    {
      Assert.Equal((byte) 1, new Person { BirthDay = 1 }.BirthDay);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.BirthMonth"/> property.</para>
    /// </summary>
    [Fact]
    public void BirthMonth_Property()
    {
      Assert.Equal((byte) 1, new Person { BirthMonth = 1 }.BirthMonth);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.BirthYear"/> property.</para>
    /// </summary>
    [Fact]
    public void BirthYear_Property()
    {
      Assert.Equal((short) 1, new Person { BirthYear = 1 }.BirthYear);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.DeathDay"/> property.</para>
    /// </summary>
    [Fact]
    public void DeathDay_Property()
    {
      Assert.Equal((byte) 1, new Person { DeathDay = 1 }.DeathDay);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.DeathMonth"/> property.</para>
    /// </summary>
    [Fact]
    public void DeathMonth_Property()
    {
      Assert.Equal((byte) 1, new Person { DeathMonth = 1 }.DeathMonth);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.DeathYear"/> property.</para>
    /// </summary>
    [Fact]
    public void DeathYear_Property()
    {
      Assert.Equal((short) 1, new Person { DeathYear = 1 }.DeathYear);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.Description"/> property.</para>
    /// </summary>
    [Fact]
    public void Description_Property()
    {
      Assert.Equal("description", new Person { Description = "description" }.Description);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new Person { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.NameFirst"/> property.</para>
    /// </summary>
    [Fact]
    public void NameFirst_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Person { NameFirst = null });
      Assert.Throws<ArgumentException>(() => new Person { NameFirst = string.Empty });
      
      Assert.Equal("nameFirst", new Person { NameFirst = "nameFirst" }.NameFirst);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.NameLast"/> property.</para>
    /// </summary>
    [Fact]
    public void NameLast_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Person { NameLast = null });
      Assert.Throws<ArgumentException>(() => new Person { NameLast = string.Empty });
      
      Assert.Equal("nameLast", new Person { NameLast = "nameLast" }.NameLast);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.NameMiddle"/> property.</para>
    /// </summary>
    [Fact]
    public void NameMiddle_Property()
    {
      Assert.Equal("nameMiddle", new Person { NameMiddle = "nameMiddle" }.NameMiddle);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.CompareTo(Person)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("NameLast", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Person.Equals(Person)"/></description></item>
    ///     <item><description><see cref="Person.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("NameFirst", "first", "second");
      this.TestEquality("NameLast", "first", "second");
      this.TestEquality("NameMiddle", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("NameFirst", "first", "second");
      this.TestHashCode("NameLast", "first", "second");
      this.TestHashCode("NameMiddle", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Person.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("NameLast NameFirst NameMiddle", new Person { NameFirst = "NameFirst", NameLast = "NameLast", NameMiddle = "NameMiddle" }.ToString());
      Assert.Equal("NameLast NameFirst", new Person { NameFirst = "NameFirst", NameLast = "NameLast" }.ToString());
    }
  }
}
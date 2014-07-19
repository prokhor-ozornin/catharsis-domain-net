using System;
using System.ComponentModel;
using Catharsis.Commons;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents abstract business entity.</para>
  /// </summary>
  [Description("Represents abstract business entity")]
  public abstract partial class Entity : IComparable<IEntity>, IEquatable<IEntity>, IEntity
  {
    /// <summary>
    ///   <para>Unique identifier of item.</para>
    /// </summary>
    [Description("Unique identifier of item")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current item instance.</para>
    /// </summary>
    [Description("Version number of current item instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Compares the current <see cref="IEntity"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IEntity"/> to compare with this instance.</param>
    public virtual int CompareTo(IEntity other)
    {
      return this.Id.CompareTo(other.Id);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IEntity"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(IEntity other)
    {
      return this.Equality(other, entity => entity.GetType(), entity => entity.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as IEntity);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(entity => entity.GetType(), entity => entity.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="IEntity"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="IEntity"/>.</returns>
    public override string ToString()
    {
      return "{0}#{1}".FormatInvariant(this.GetType(), this.Id);
    }
  }
}
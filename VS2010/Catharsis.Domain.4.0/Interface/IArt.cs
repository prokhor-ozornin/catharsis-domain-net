namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a creative image which is usually displayed publically.</para>
  /// </summary>
  public partial interface IArt : IItem
  {
    /// <summary>
    ///   <para>Album that contains the art.</para>
    /// </summary>
    IArtsAlbum Album { get; }

    /// <summary>
    ///   <para>URI of art's graphical image.</para>
    /// </summary>
    string Image { get; }

    /// <summary>
    ///   <para>Name of art's physical material.</para>
    /// </summary>
    string Material { get; }

    /// <summary>
    ///   <para>Creator of the art.</para>
    /// </summary>
    IPerson Person { get;  }

    /// <summary>
    ///   <para>Place of art's physical exposition.</para>
    /// </summary>
    string Place { get;  }
  }
}
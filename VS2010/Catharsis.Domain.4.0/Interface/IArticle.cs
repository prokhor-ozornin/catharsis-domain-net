namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a long informational text.</para>
  /// </summary>
  public partial interface IArticle : IItem
  {
    /// <summary>
    ///   <para>Short summary of article.</para>
    /// </summary>
    string Annotation { get;  }

    /// <summary>
    ///   <para>Category of article.</para>
    /// </summary>
    IArticlesCategory Category { get;  }

    /// <summary>
    ///   <para>URI of article's image.</para>
    /// </summary>
    string Image { get;  }
  }
}
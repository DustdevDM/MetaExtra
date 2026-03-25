using MetaExtra.Core.Sources;

namespace MetaExtra.Core;

/// <summary>
/// Defines a metadata extractor for one or more file types.
/// </summary>
public interface IMetadataExtractor
{
    /// <summary>
    /// File extensions this extractor handles, in lowercase with a leading dot.
    /// Example: [".pdf"], [".jpg", ".jpeg"]
    /// </summary>
    IReadOnlyList<string> SupportedExtensions { get; }

    /// <summary>
    /// Performs an optional deeper check (e.g. magic bytes) to confirm
    /// this extractor can handle the given source.
    /// Called after the extension check as a secondary guard.
    /// </summary>
    bool CanHandle(IFileSource source);

    /// <summary>
    /// Extracts metadata from the given file source.
    /// </summary>
    Task<FileMetadata> ExtractAsync(IFileSource source, CancellationToken cancellationToken = default);
}
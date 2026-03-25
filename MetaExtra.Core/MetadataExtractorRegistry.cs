using MetaExtra.Core.Sources;

namespace MetaExtra.Core;

/// <summary>
/// Resolves and dispatches to the correct <see cref="IMetadataExtractor"/>
/// for a given file source. Extractors are matched first by extension,
/// then confirmed via <see cref="IMetadataExtractor.CanHandle"/>.
/// </summary>
public sealed class MetadataExtractorRegistry(IEnumerable<IMetadataExtractor> extractors)
{
    private readonly IReadOnlyList<IMetadataExtractor> extractors = extractors.ToList();

    /// <summary>
    /// Finds the first extractor that supports the given source.
    /// Returns null if none is found.
    /// </summary>
    public IMetadataExtractor? Resolve(IFileSource source)
    {
        var candidates = extractors
            .Where(e => e.SupportedExtensions.Contains(source.Extension, StringComparer.OrdinalIgnoreCase))
            .ToList();
        
        return candidates.FirstOrDefault(e => e.CanHandle(source));
    }

    /// <summary>
    /// Extracts metadata from the source using the appropriate extractor.
    /// Throws <see cref="NotSupportedException"/> if no extractor is registered for the file type.
    /// </summary>
    public async Task<FileMetadata> ExtractAsync(IFileSource source, CancellationToken cancellationToken = default)
    {
        var extractor = Resolve(source)
            ?? throw new NotSupportedException(
                $"No extractor registered for file '{source.FileName}' (extension: '{source.Extension}').");

        return await extractor.ExtractAsync(source, cancellationToken);
    }
}
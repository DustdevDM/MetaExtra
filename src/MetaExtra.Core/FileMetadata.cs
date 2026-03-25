namespace MetaExtra.Core;

/// <summary>
/// A flat, dictionary-style bag of metadata key-value pairs extracted from a file.
/// Each extractor populates the entries relevant to its file type.
/// </summary>
public sealed class FileMetadata
{
    private readonly Dictionary<string, object?> entries = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>The file name this metadata was extracted from.</summary>
    public string FileName { get; init; } = string.Empty;

    /// <summary>The MIME type identified for this file, if determinable.</summary>
    public string? MimeType { get; init; }

    /// <summary>All extracted metadata entries.</summary>
    public IReadOnlyDictionary<string, object?> Entries => entries;

    /// <summary>Sets a metadata entry.</summary>
    public void Set(string key, object? value) => entries[key] = value;

    /// <summary>Gets a typed metadata entry, or the default value if not present.</summary>
    public T? Get<T>(string key) =>
        entries.TryGetValue(key, out var value) && value is T typed ? typed : default;

    /// <summary>Returns true if a key exists and is non-null.</summary>
    public bool Has(string key) =>
        entries.TryGetValue(key, out var value) && value is not null;
}
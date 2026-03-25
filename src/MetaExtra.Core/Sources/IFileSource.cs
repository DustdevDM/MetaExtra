namespace MetaExtra.Core.Sources;

/// <summary>
/// Represents an abstract file source that can be backed by the filesystem,
/// a memory buffer, or any other stream provider.
/// </summary>
public interface IFileSource
{
    /// <summary>The file name including extension, e.g. "document.pdf"</summary>
    string FileName { get; }

    /// <summary>The file extension in lowercase, e.g. ".pdf"</summary>
    string Extension { get; }

    /// <summary>The full path on disk, or null if not backed by the filesystem.</summary>
    string? FilePath { get; }

    /// <summary>The file size in bytes, if known.</summary>
    long? FileSizeBytes { get; }

    /// <summary>Opens a readable stream over the file content.</summary>
    Stream OpenRead();

    /// <summary>
    /// Reads the first <paramref name="byteCount"/> bytes without opening a full stream.
    /// Used for magic byte sniffing.
    /// </summary>
    byte[] PeekHeader(int byteCount);
}
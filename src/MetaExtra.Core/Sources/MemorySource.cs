namespace MetaExtra.Core.Sources;

/// <summary>
/// An <see cref="IFileSource"/> backed by an in-memory byte array.
/// </summary>
public sealed class MemorySource : IFileSource
{
    private readonly byte[] data;

    public MemorySource(byte[] data, string fileName)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

        this.data = data;
        FileName = fileName;
        Extension = Path.GetExtension(fileName).ToLowerInvariant();
    }

    public string FileName { get; }
    public string Extension { get; }
    public string? FilePath => null;
    public long? FileSizeBytes => data.Length;

    public Stream OpenRead() => new MemoryStream(data, writable: false);

    public byte[] PeekHeader(int byteCount)
    {
        var length = Math.Min(byteCount, data.Length);
        var buffer = new byte[length];
        Array.Copy(data, buffer, length);
        return buffer;
    }
}
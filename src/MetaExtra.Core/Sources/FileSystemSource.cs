namespace MetaExtra.Core.Sources;

/// <summary>
/// An <see cref="IFileSource"/> backed by a file on disk.
/// </summary>
public sealed class FileSystemSource : IFileSource
{
    private readonly FileInfo fileInfo;

    public FileSystemSource(string path) : this(new FileInfo(path)) { }

    public FileSystemSource(FileInfo fileInfo)
    {
        ArgumentNullException.ThrowIfNull(fileInfo);
        if (!fileInfo.Exists)
            throw new FileNotFoundException("File not found.", fileInfo.FullName);

        this.fileInfo = fileInfo;
    }

    public string FileName => fileInfo.Name;
    public string Extension => fileInfo.Extension.ToLowerInvariant();
    public string? FilePath => fileInfo.FullName;
    public long? FileSizeBytes => fileInfo.Length;

    public Stream OpenRead() => fileInfo.OpenRead();

    public byte[] PeekHeader(int byteCount)
    {
        using var stream = fileInfo.OpenRead();
        var buffer = new byte[Math.Min(byteCount, (int)fileInfo.Length)];
        _ = stream.Read(buffer, 0, buffer.Length);
        return buffer;
    }
}
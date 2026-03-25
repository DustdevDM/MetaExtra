namespace MetaExtra.Core;

/// <summary>
/// Standardised key names for common metadata entries.
/// Extractors should prefer these over ad-hoc strings for interoperability.
/// </summary>
public static class MetadataKeys
{
    // --- Common ---
    public const string Title       = "Title";
    public const string Author      = "Author";
    public const string CreatedAt   = "CreatedAt";
    public const string ModifiedAt  = "ModifiedAt";
    public const string Subject     = "Subject";
    public const string Keywords    = "Keywords";
    public const string Language    = "Language";

    // --- PDF ---
    public const string PdfPageCount   = "Pdf.PageCount";
    public const string PdfProducer    = "Pdf.Producer";
    public const string PdfCreator     = "Pdf.Creator";
    public const string PdfVersion     = "Pdf.Version";
    public const string PdfIsEncrypted = "Pdf.IsEncrypted";

    // --- Image ---
    public const string ImageWidth      = "Image.Width";
    public const string ImageHeight     = "Image.Height";
    public const string ImageColorDepth = "Image.ColorDepth";
    public const string ImageDpiX       = "Image.DpiX";
    public const string ImageDpiY       = "Image.DpiY";

    // --- Audio ---
    public const string AudioDuration   = "Audio.Duration";
    public const string AudioBitrate    = "Audio.Bitrate";
    public const string AudioSampleRate = "Audio.SampleRate";
    public const string AudioChannels   = "Audio.Channels";
}
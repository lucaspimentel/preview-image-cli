namespace Preview.Image.Cli;

public readonly struct Arguments(string? path, int? maxWidth)
{
    private const string MaxWidthArgName = "--max-width=";

    public readonly string? Path = path;
    public readonly int? MaxWidth = maxWidth;

    public static Arguments Parse(string[] args)
    {
        string? path = null;
        int? maxWidth = null;

        foreach (var arg in args)
        {
            if (arg.StartsWith(MaxWidthArgName) && int.TryParse(arg.AsSpan(MaxWidthArgName.Length), out var width))
            {
                maxWidth = width;
            }
            else
            {
                path = arg;
            }
        }

        return new Arguments(path, maxWidth);
    }
}

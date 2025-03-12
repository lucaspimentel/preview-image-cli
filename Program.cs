using Preview.Image.Cli;
using Spectre.Console;

var arguments = Arguments.Parse(args);

if (arguments.Path is null)
{
    AnsiConsole.MarkupLine("[red]Please provide a path to an image file.[/]");
    return;
}

if (!File.Exists(arguments.Path))
{
    AnsiConsole.MarkupLine("[red]The specified file does not exist.[/]");
    return;
}

var image = new CanvasImage(arguments.Path)
{
    MaxWidth = arguments.MaxWidth,
};

AnsiConsole.Write(image);

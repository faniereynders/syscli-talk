using clippt;
using System.Drawing;
using static Colorful.Console;
using static System.Environment;
public class _1__Intro : ISlide
{
    public int Index => 2;
    public async Task Execute()
    {
        WriteLine();
        WriteLine();
        WriteAscii("System.CommandLine", Colorful.FigletFont.Load("./Fonts/mini.flf"), Color.LawnGreen);
        WriteAscii("demystified", Colorful.FigletFont.Load("./Fonts/big.flf"), Color.LightCyan);
        WriteLine();

        await Task.CompletedTask;

    }
}

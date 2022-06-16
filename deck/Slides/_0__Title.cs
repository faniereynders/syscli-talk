using clippt;
using System.Drawing;
using Colorful;
using static Colorful.Console;
using static System.Environment;
public class _1__Title : ISlide
{
    public int Index => 1;
    public async Task Execute()
    {
        //https://dotnetcoretutorials.com/2021/01/16/creating-modern-and-helpful-command-line-utilities-with-system-commandline/
        WriteLine();
        WriteLine();

        //ImageAscii.Render("./Images/terminal_icon.png", 30);

        WriteAscii("Sys.CmdLine", Fonts.H1);
        WriteAscii("Demystified", Fonts.H2, Color.AntiqueWhite);
        WriteLine();

        await Task.CompletedTask;
 
    }
}

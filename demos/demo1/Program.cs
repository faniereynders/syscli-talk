using System.CommandLine;
using System.IO;
using static System.Console;

var rootCommand = new RootCommand("A CLI for .NET Amsterdam");

var greetCommand = new Command("greet", "Greets the group with current datetime");
greetCommand.SetHandler(() => WriteLine($"Hello meetup, the time is now {DateTime.Now}"));


var echoCommand = new Command("echo", "Echos the input");
var outputArgument = new Argument<Outputs>("output", "The output type");
var messageOption = new Option<string>(new[] { "--message", "-m" }, "Message to display");
var upperOption = new Option<bool>("--upper", "Upper case the message");

echoCommand.AddArgument(outputArgument);
echoCommand.AddOption(upperOption);
echoCommand.AddOption(messageOption);

echoCommand.SetHandler((output, message, isUpper) =>
{
    if (isUpper)
    {
        message = message.ToUpper();
    }

    if (output == Outputs.Console)
    {
        WriteLine(message);
    }
    else
    {
        File.WriteAllText("output.txt", message);
    }

}, outputArgument, messageOption, upperOption);





rootCommand.AddCommand(echoCommand);
rootCommand.AddCommand(greetCommand);

await rootCommand.InvokeAsync(args);
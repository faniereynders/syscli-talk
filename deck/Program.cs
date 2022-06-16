
using clippt;

var deck = new Deck();

var startSlide = 0;

if (args.Length > 0 && int.TryParse(args[0], out startSlide))
{
    startSlide = int.Parse(args[0]);
}

deck.Start(
    slide: 1,
    end: () =>
    {
        Console.WriteLine("End of show");
        Console.ReadKey();
    }
);



public static class Fonts {
    public static Colorful.FigletFont H1 = Colorful.FigletFont.Load("./Fonts/colossal.flf");
    public static Colorful.FigletFont H2 = Colorful.FigletFont.Load("./Fonts/big.flf");
} 
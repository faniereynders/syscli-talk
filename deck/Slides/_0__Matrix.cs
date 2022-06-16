using clippt;

public class _0__Matrix : ISlide
{
    public int Index => 0;
    public async Task Execute()
    {
        Matrix();
        
    }
    // fields
    Random rand = new Random();
    // properties
    char AsciiCharacter
    {
        get
        {
            int t = rand.Next(10);
            if (t <= 2)
                // returns a number
                return (char)('0' + rand.Next(10));
            else if (t <= 4)
                // small letter
                return (char)('a' + rand.Next(27));
            else if (t <= 6)
                // capital letter
                return (char)('A' + rand.Next(27));
            else
                // any ascii character
                return (char)(rand.Next(32, 255));
        }
    }
    private void Matrix()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.CursorVisible = false;
        int width, height;
        // setup array of starting y values
        int[] y;
        // width was 209, height was 81
        // setup the screen and initial conditions of y
        Initialize(out width, out height, out y);
        // do the Matrix effect
        // every loop all y's get incremented by 1
        var splash = true;
        while (splash)
        {
            splash = UpdateAllColumns(width, height, y);
            System.Threading.Thread.Sleep(100);
        }
        Console.CursorVisible = true;
    }
    private bool UpdateAllColumns(int width, int height, int[] y)
    {
        int x;
        // draws 3 characters in each x column each time... 
        // a dark green, light green, and a space
        // y is the position on the screen
        // y[x] increments 1 each time so each loop does the same thing but down 1 y value
        for (x = 0; x < width; ++x)
        {
            // the bright green character
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y[x]);
            Console.Write(AsciiCharacter);
            // the dark green character -  2 positions above the bright green character
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int temp = y[x] - 2;
            Console.SetCursorPosition(x, inScreenYPosition(temp, height));
            Console.Write(AsciiCharacter);
            // the 'space' - 20 positions above the bright green character
            int temp1 = y[x] - 20;
            Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
            Console.Write(' ');
            // increment y
            y[x] = inScreenYPosition(y[x] + 1, height);
        }
        // F5 to reset, F11 to pause and unpause
        if (Console.KeyAvailable)
        {
            var input = Console.ReadKey();
            
            if (input.Key == ConsoleKey.F5)
                Initialize(out width, out height, out y);
            if (input.Key == ConsoleKey.RightArrow)
                return false;
        }
        return true;
    }
    // Deals with what happens when y position is off screen
    public int inScreenYPosition(int yPosition, int height)
    {
        if (yPosition < 0)
            return yPosition + height;
        else if (yPosition < height)
            return yPosition;
        else
            return 0;
    }
    // only called once at the start
    private void Initialize(out int width, out int height, out int[] y)
    {
        height = Console.WindowHeight;
        width = Console.WindowWidth - 1;
        // 209 for me.. starting y positions of bright green characters
        y = new int[width];
        Console.Clear();
        // loops 209 times for me
        for (int x = 0; x < width; ++x)
        {
            // gets random number between 0 and 81
            y[x] = rand.Next(height);
        }
    }
}

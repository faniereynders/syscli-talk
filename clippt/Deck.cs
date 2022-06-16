using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace clippt;
public class Deck
{
    private readonly ISlide[] slides;
    
    public Deck()
    {
        var services = new ServiceCollection();
        var provider = services.Scan(scan => scan
                 .FromAssemblies(Assembly.GetEntryAssembly())
                 .AddClasses(classes => classes.AssignableTo<ISlide>())
                 .AsImplementedInterfaces()
                 .WithTransientLifetime())
                 .BuildServiceProvider();
        slides = provider.GetServices<ISlide>().OrderBy(s=>s.Index).ToArray();
    }
    public ISlide[] Slides => slides;
    public void Start(Action setup = null, int slide = 0, Action end = null)
    {
        var id = slide;
        //Setup();
        if (setup != null) setup();
        while (true)
        {
            Reset();
            slides[id].Execute().Wait();
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.RightArrow)
            {
                id++;
            }
            else if (key.Key == ConsoleKey.LeftArrow && id > 0)
            {
                id--;
            }
            if (id >= slides.Length)
            {
                break;
            }
        }
        Reset();
        if (end != null) end();
    }
    protected virtual void Reset()
    {
        Console.Clear();
        Console.ResetColor();
    }

}
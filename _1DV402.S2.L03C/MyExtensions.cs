using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DV402.S2.L03C.Properties;

public class MyExtensions
{
    //Changes appearance of console window
    public static void PrettyConsole(string title, ConsoleColor backgroundColor = ConsoleColor.White, ConsoleColor foregroundColor = ConsoleColor.Black)
    {
        Console.Title = title;
        ChangeColor(backgroundColor, foregroundColor);
        Console.Clear();
    }

    
    //Changes appearance of console text
    public static void ChangeColor(ConsoleColor backgroundColor = ConsoleColor.White, ConsoleColor foregroundColor = ConsoleColor.Black)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = foregroundColor;
    }
}

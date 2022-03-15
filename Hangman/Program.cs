using System;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
public class Program
{
    public static void Main(string[] args)
    {
        string[] words = File.ReadAllLines("wortliste.txt");

        Game game = new Game(words);
        game.Run();





    }

}
using Scoolio.TimeTableWatcher.Manos.Crawler;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var crawler = new ManosCrawler();
        crawler.GetTimeTableChanges();
        Console.ReadLine();
    }
}
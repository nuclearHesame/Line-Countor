using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string projectPath;
        projectPath = Console.ReadLine();

        List<string> extentions = new List<string>();
        string extention = null;

        while (extention != "")
        {
            extentions.Add(extention);
            Console.Write("Please Enter extentions:");
            extention = Console.ReadLine();
        }

        int totalLinesOfCode = CountLinesOfCode(projectPath, extentions);

        Console.WriteLine($"Total lines of code files: {totalLinesOfCode}");

        Console.ReadKey();
    }

    static int CountLinesOfCode(string path, List<string> extentions)
    {
        try
        {
            int totalLines = 0;

            foreach (var extention in extentions)
            {
                var files = Directory.GetFiles(path, "*." + extention,SearchOption.TopDirectoryOnly);

                foreach (var file in files)
                {
                    string[] lines = File.ReadAllLines(file);
                    totalLines += lines.Length;
                }
            }

            return totalLines;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return -1;
        }
    }
}

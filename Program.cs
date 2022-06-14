using System;
using System.Collections.Generic;
using XMLCyclofan.Models;

namespace XMLCyclofan
{
    class Program
    {
        static void Main(string[] args)
        {
            var project = new Project();
            project.Tools = new List<Tool>();
            project.Parts = new List<Part>();

            for (int i = 0; i < 10; i++)
            {
                project.Tools.Add(new Tool(i, "bla bla bla", 1, "bla bla bla"));
            }

            for (int i = 0; i < 10; i++)
            {
                project.Parts.Add(new Part(i, "TIPO", i, true, "bla bla bla", null));
            }

            project.Parts[3].Flag = false;

            foreach (var part in project.Parts)
            {
                if (!part.Flag)
                    Console.WriteLine($"Peça {part.Id} | {part.Type}  retirada!");
            }


            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}

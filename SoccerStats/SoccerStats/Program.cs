using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // new!

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {

            // print all text files in the directory
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var files = directory.GetFiles("*.txt");

            foreach(var f in files)
            {
                System.Console.WriteLine(f.Name);
            }

            System.Console.ReadLine();

            // read from file specified
            string currentDirectory2 = Directory.GetCurrentDirectory();
            DirectoryInfo directory2 = new DirectoryInfo(currentDirectory2);
            var fileName = Path.Combine(directory2.FullName, "data.txt");
            var file = new FileInfo(fileName);

            if (file.Exists)
            {
                using (var reader = new StreamReader(fileName))
                {
                    Console.SetIn(reader);
                }
            }

            //csv
            string currentDirectory3 = Directory.GetCurrentDirectory();
            DirectoryInfo directory3 = new DirectoryInfo(currentDirectory3);
            string fileName2 = Path.Combine(directory3.FullName, "SoccerGameResults.csv");
            var fileContents = ReadFile(fileName2);

            //create line breaks in output
            string[] fileLines = fileContents.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in fileLines) {
                Console.WriteLine(line);

            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

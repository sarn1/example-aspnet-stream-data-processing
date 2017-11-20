using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // new!
using static SoccerStats.GameResult;
using Newtonsoft.Json;

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
                System.Console.WriteLine(f.Name);  //1) output available files
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
                    Console.WriteLine(reader.ReadLine()); //2) output hello world in file
                }
            }

            // csv
            string currentDirectory3 = Directory.GetCurrentDirectory();
            DirectoryInfo directory3 = new DirectoryInfo(currentDirectory3);
            string fileName2 = Path.Combine(directory3.FullName, "SoccerGameResults.csv");
            var fileContents = ReadFile(fileName2);

            // create line breaks in output
            string[] fileLines = fileContents.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in fileLines) {
                Console.WriteLine(line); //3) output all data in csv

            }

            // use ReadSoccerResults
            Console.WriteLine("-------------------------");
            var fileContents2 = ReadSoccerResults(fileName); //4) example creating and using objects

            //5) JSON NuGet
            Console.WriteLine("------------TOP 10-------------");
            string currentDirectory4 = Directory.GetCurrentDirectory();
            DirectoryInfo directory4 = new DirectoryInfo(currentDirectory4);
            var fileName3 = Path.Combine(directory4.FullName, "SoccerGameResults.csv");
            var fileContents3 = ReadSoccerResults(fileName3);
            fileName3 = Path.Combine(directory4.FullName, "players.json");
            var players = DeserializePlayers(fileName3);
            var topTenPlayers = GetTopTenPlayers(players);

            foreach(var player in topTenPlayers)
            {
                Console.WriteLine(player.FirstName + " " + player.points_per_game + " PPG");
            }

            //6) Write To File
            fileName3 = Path.Combine(directory4.FullName, "topten.json"); //file is in bin/debug
            SerializePlayerToFile(topTenPlayers, fileName3);

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        // read entire file
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        // read line by line
        public static List<GameResult> ReadSoccerResults(string fileName) {
            var soccerResults = new List<GameResult>();
            using(var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();

                //peak gives you position of character, if -1 then eof
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');

                    DateTime gameDate;
                    
                    //out = pass by ref.
                    if(DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if(Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.oHomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }

                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttmpts = parseInt;
                    }

                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }

                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    double posessionPercent;
                    if (double.TryParse(values[7], out posessionPercent)) {
                        gameResult.PossessionPercent = posessionPercent;
                    }



                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize <List<Player>> (jsonReader);
            }

            return players;
        }

        public static List<Player> GetTopTenPlayers (List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());
            int counter = 0;

            foreach(var player in players)
            {
                topTenPlayers.Add(player);
                counter++;
                if (counter == 10)
                    break;
            }

            return topTenPlayers;
        }

        public static void SerializePlayerToFile(List<Player>players, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
        }
    }
}

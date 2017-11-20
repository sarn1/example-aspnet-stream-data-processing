using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{

    public class Rootobject
    {
        public Player[] Player { get; set; }
    }

    public class Player
    {
        [JsonProperty(PropertyName="first_name")]
        public string FirstName { get; set; } //instead of first_name as in file
        public int id { get; set; }
        public double points_per_game { get; set; }
        public string second_name { get; set; }
        public string team_name { get; set; }
    }

}

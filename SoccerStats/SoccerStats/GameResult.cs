using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{
    public class GameResult
    {
        public DateTime GameDate { get; set; }
        public string TeamName { get; set; }
        public HomeOrAway oHomeOrAway { get; set; }
        public int Goals { get; set; }
        public int GoalAttmpts { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsOffGoal { get; set; }
        public double PossessionPercent { get; set; }
        public double ConversionRate
        {
            get
            {
                return (double)Goals / (double)GoalAttmpts;
            }
        }

        //since csv value for this column has either home or away value
        public enum HomeOrAway
        {
            Home,
            Away
        }
    }
}

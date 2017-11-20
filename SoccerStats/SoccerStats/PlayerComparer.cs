using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{
    class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.points_per_game.CompareTo(y.points_per_game) * -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShootsAndLadders
{
    public class Square
    {
        public List<Player> Players { get; set; }
        public int? ShootTo { get; set; }
        public int? LadderTo { get; set; }

        public Square()
        {
            Players = new List<Player>();
        }
    }
}

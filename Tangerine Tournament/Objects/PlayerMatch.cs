using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Tournament.Objects;

namespace Tangerine_Tournament.Objects
{
    public class PlayerMatch
    {
        public Player Player1 { get; }
        public Player Player2 { get; }

        public Player Winner { get; set; }
        public int Stage { get; set; }

        public PlayerMatch(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
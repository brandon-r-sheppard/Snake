using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Snake.GameLogic
{
    public abstract class Game
    {
        private string _gameId;
        private List<Player> _players = new List<Player>();
        public abstract void AddPlayer(Player player);
        public abstract void RemovePlayer(Player player);
        public abstract Dictionary<String, Snake> PingSnakes();
        public abstract Boolean IsGameOver();
    }
}
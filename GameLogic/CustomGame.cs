using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snake.Data;

namespace Snake.GameLogic
{
    public class CustomGame : Game
    {
        private string _gameId;
        private string _hostId;
        private List<Player> _players = new List<Player>();
        public int Rounds
        {
            get; set;
        }
        public int CurrentRound
        {
            get; protected set;
        }
        public CustomGame(string gameId, Player host)
        {
            _gameId = gameId;
            _hostId = host.ConnectionId;
            _players.Add(host);
        }
        public override void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        public override void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }
        public override Dictionary<string, Snake> PingSnakes()
        {
            Dictionary<String, Snake> snakes = new Dictionary<String, Snake>();
            foreach (Player p in _players)
            {
                snakes.Add(p.Name, p.SnakeInfo);
            }
            return snakes;
        }
        public Boolean IsRoundOver()
        {
            int alive = 0;
            foreach (Player p in _players)
            {
                if (p.SnakeInfo.isAlive)
                {
                    alive++;
                }
            }
            if (alive >= 2)
            {
                return false;
            }
            return true;
        }
        public override Boolean IsGameOver()
        {
            if(CurrentRound > Rounds)
            {
                return true;
            } else if (_players.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}

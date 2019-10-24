using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.GameLogic
{
    public class PublicGame : Game
    {
        public string _gameId;
        public List<Player> _players = new List<Player>();

        public override void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public override void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }

        public override Dictionary<String, Snake> PingSnakes()
        {
            Dictionary<String, Snake> snakes = new Dictionary<String, Snake>();
            foreach(Player p in _players)
            {
                snakes.Add(p.Name, p.SnakeInfo);
            }
            return snakes;
        }

        public override Boolean IsGameOver()
        {
            int alive = 0;
            foreach(Player p in _players)
            {
                if (p.SnakeInfo.isAlive)
                {
                    alive++;
                }
            }
            if(alive >= 2)
            {
                return false;
            }
            return true;
        } 
    }
}

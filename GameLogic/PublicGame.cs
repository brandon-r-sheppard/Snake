using Snake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace Snake.GameLogic
{
    public class PublicGame : Game
    {
        public string _gameId;
        public List<Player> _players = new List<Player>();

        public override void AddPlayer(Player player)
        {
            Snake newSnake = new Snake();
            Random random = new Random();
            switch (_players.Count)
            {
                case 0:
                    newSnake.pos = new Vector2(10,10);

                    newSnake.direction = 1;
                    break;
                case 1:
                    newSnake.pos = new Vector2(590, 10);
                    newSnake.direction = -1;
                    break;
                case 2:
                    newSnake.pos = new Vector2(10, 590);
                    newSnake.direction = 1;
                    break;
                case 3:
                    newSnake.pos = new Vector2(590, 590);
                    newSnake.direction = -1;
                    break;
                default:
                    Console.WriteLine("Why is there here");
                    break;
            }
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

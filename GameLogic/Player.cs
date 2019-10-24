using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.GameLogic
{
    public class Player
    {
        private string _name;
        private int _userId;
        private string _connectionId;
        private Snake _snake = null;
        public Snake Snake
        {
            get
            {
                return _snake;
            }
            set
            {
                _snake = value;
            }
        }
        /// <summary>
        /// Elo is used to measure the rank of the player 
        /// based on performance of matchmaking
        /// </summary>
        private int _elo;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
        }

        public string ConnectionId
        {
            get
            {
                return _connectionId;
            }
        }

        public string Rank
        {
            get
            {
                if(_elo <= 400)
                {
                    return "Python";
                } else if(_elo <= 200)
                {
                    return "Viper";
                }
                return "Cobra";
            }
        }

        public Player(String name, int userId, string connectionId)
        {
            _name = name;
            _userId = userId;
            _connectionId = connectionId;
        }
        public override string ToString()
        {
            return $"Player: {_name} ID: {_userId} Elo: {_elo} Connection ID: {_connectionId}";
        }
    }
}

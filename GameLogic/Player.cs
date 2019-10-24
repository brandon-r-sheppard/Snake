using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.GameLogic
{
    public class Player
    {
        private string _name;
        private string _user_id;
        private string _connection_id;
        private Snake _snake;
        public Snake SnakeInfo
        {
            get
            {
                return _snake;
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

        public string UserId
        {
            get
            {
                return _user_id;
            }
        }

        public string ConnectionId
        {
            get
            {
                return _connection_id;
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

        public override string ToString()
        {
            return $"Player: {_name} ID: {_user_id} Elo: {_elo} Connection ID: {_connection_id}";
        }
    }
}

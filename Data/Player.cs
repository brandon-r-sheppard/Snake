using Snake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Data
{
    public class Player
    {
        /// <summary>
        /// Unique username of the player.
        /// </summary>
        private string _name;
       
        /// <summary>
        /// Unique User Id of the player.
        /// </summary>
        private int _userId;
        
        /// <summary>
        /// Returns whether or not the user has verified their email.
        /// </summary>
        private Boolean _isVerified;

        /// <summary>
        /// Integer based ranking system (0 - 600) used to calculate
        /// player skill level.
        /// </summary>
        private int _elo;

        /// <summary>
        /// Returns the Username of the player.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Returns User Id of the player.
        /// </summary>
        public int UserId
        {
            get
            {
                return _userId;
            }
        }

        /// <summary>
        /// Returns if the user has verified their email or not.
        /// </summary>
        private Boolean IsVerified
        {
            get
            {
                return _isVerified;
            }
        }

        /// <summary>
        /// Returns a Rank enum of the players rank.
        /// </summary>
        public Rank PlayerRank
        {
            get
            {
                if(_elo <= 400)
                {
                    return Rank.PYTHON;
                } else if(_elo <= 200)
                {
                    return Rank.VIPER;
                }
                return Rank.BOA;
            }
        }
        
        /// <summary>
        /// Constructor for Player Object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <param name="isVerified"></param>
        /// <param name="elo"></param>
        public Player(String name, int userId, Boolean isVerified, int elo)
        {
            _name = name;
            _userId = userId;
            _isVerified = isVerified;
            _elo = elo;
        }

        /// <summary>
        /// ToString method returns Username, UserId and PlayerRank.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Player: {_name} ID: {_userId} Rank: {PlayerRank}";
        }
    }
}

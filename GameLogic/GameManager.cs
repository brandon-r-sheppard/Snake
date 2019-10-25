using Snake.Data;
using Snake.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake
{
    public class GameManager
    {
        /// <summary>
        /// Game Managaer instance to hold our Singleton.
        /// </summary>
        private static GameManager _instance = null;
        
        /// <summary>
        /// Readonly lock to secure our Singleton to a single thread.
        /// </summary>
        private static readonly object _padlock = new object();
        
        /// <summary>
        /// Static _rng class used within the class.
        /// </summary>
        private static Random _rng = new Random();
        
        /// <summary>
        /// GameManager property that returns the GameManager Singleton.
        /// </summary>
        public static GameManager GameManagerInstance
        {
            get
            {
                //Without a lock this singleton is not thread safe
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new GameManager();
                    }
                }
                return _instance;
            }
        }
       
        /// <summary>
        /// Contains a list of con-current games, public and custom.
        /// </summary>
        private Dictionary<String, Game> _games = new Dictionary<String, Game>();
        
        /// <summary>
        /// _players holds the connection id of each connected client.
        /// </summary>
        private List<String> _players = new List<String>();

        /// <summary>
        /// _matchmakingQueue holds a queue of connected clients looking
        /// for a match.
        /// </summary>
        private Queue<String> _matchmakingQueue = new Queue<String>();

        /// <summary>
        /// Generates a 6 digit hexidecimal number used for custom games.
        /// </summary>
        /// <returns></returns>
        public string GenerateCustomGameId()
        {
            //Length of generated code.
            const int idLength = 6;
            //Code to give sender
            string output = "";

            //Character set of available characters
            const string characters = "0123456789ABCDEF";
            do
            {
                for (int i = 0; i < idLength; i++)
                {
                    //Add random character to the array of characters
                    char[] chars = characters.ToCharArray();
                    output += chars[_rng.Next(0, characters.Length)];
                }
            }
            while (_games.ContainsKey(output.ToString())); //End when Game Id is unique
            return output;
        }

        /// <summary>
        /// Adds client to matchmaking queue.
        /// </summary>
        /// <param name="p"></param>
        public void JoinQueue(string clientConnectionId)
        {
            if (!_players.Contains(clientConnectionId))
            {
                _players.Add(clientConnectionId);
            }
            _matchmakingQueue.Enqueue(clientConnectionId);
        }

        /// <summary>
        /// Removes client from matchmaking queue.
        /// </summary>
        /// <param name=""></param>
        public void LeaveQueue(string clientConnectionId)
        {
            
            if(_matchmakingQueue.Contains(clientConnectionId))
                _matchmakingQueue = new Queue<String>(_matchmakingQueue.Where(connectionId => connectionId != clientConnectionId));
        }
        
        /*public string generateGame(List<Player> players)
        {
        }*/

        public Boolean gameIsValid(string gameId)
        {
            return _games.ContainsKey(gameId);
        }
    }
}

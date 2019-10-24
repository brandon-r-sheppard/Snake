﻿using Snake.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake
{
    public class GameManager
    {
        private static GameManager _instance = null;
        private static readonly object _padlock = new object();
        private static Random _rng = new Random();
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

        private Dictionary<String, Object> _games = new Dictionary<String, Object>();
        private List<Player> _players = new List<Player>();
        private Dictionary<String, Object> _availablePlayers = new Dictionary<String, Object>();
        public string generateGameId()
        {
            const int idLength = 6;
            string output = "";

            //Character set of available characters
            const string characters = "0123456789ABCDEF";
            do
            {
                for (int i = 0; i < idLength; i++)
                {
                    char[] chars = characters.ToCharArray();
                    output += chars[_rng.Next(0, characters.Length)];
                }
            }
            while (_games.ContainsKey(output.ToString()));
            return output;
        }

        public string generateGame(string gameId, Player host)
        {
            Game game = new Game(gameId, host);
            _games.Add(gameId, game);
            return game.ToString();
        }

        public Boolean gameIsValid(string gameId)
        {
            return _games.ContainsKey(gameId);
        }
    }
}

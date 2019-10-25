using Microsoft.AspNetCore.SignalR;
using Snake.GameLogic;
using Snake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Hubs
{
    public class SnakeHub : Hub
    {
        private GameManager _gm = GameManager.GameManagerInstance;
        private DatabaseManager _db = DatabaseManager.DatabaseManagerInstance;
        public async Task JoinGame()
        {
        }
        public async Task CreateGame()
        {
        }

        public async Task joinGame(string gameId)
        {

        }

        public async Task Reigster(string username, string password, string email)
        {
            if(_db.UsernameExists(username) && _db.)
            _db.Register(username, password, email);
            
        }

        public async Task Login(string username, string password)
        {

        }

        public async Task VerifyEmail(string emailVerificationCode)
        {

        }

        public async Task ResetPassword(string email)
        {

        }

        public async Task PingSnakes()
        {

        }

        public async Task SnakeDied()
        {

        }

        public async Task FoodEaten()
        {

        }
    }
}

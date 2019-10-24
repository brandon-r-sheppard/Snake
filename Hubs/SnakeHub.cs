using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Hubs
{
    public class SnakeHub : Hub
    {
        private GameManager _gm = GameManager.GameManagerInstance;
        public async Task createGame()
        {
            string gameId = _gm.generateGameId();
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.Caller.SendAsync("gameInfo", _gm.generateGame(gameId, Context.ConnectionId));
        }

        public async Task joinGame(string gameId)
        {
            if (_gm.gameIsValid(gameId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
                await Clients.Caller.SendAsync("joined", "true");
                await Clients.Group(gameId).SendAsync("playerJoin", "Player has joined the game!");
            } else
            {
                await Clients.Caller.SendAsync("joined", "false");
            }
            
        }   
    }
}

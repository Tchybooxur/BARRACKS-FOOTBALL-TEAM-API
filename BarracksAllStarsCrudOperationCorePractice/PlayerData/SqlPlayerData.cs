using BarracksAllStarsCrudOperationCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksAllStarsCrudOperationCorePractice.PlayerData
{
    public class SqlPlayerData : IPlayerData
    {
        private PlayerContext _playerContext;
        public SqlPlayerData(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }
        public Player AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid();
            _playerContext.Players.Add(player);
            _playerContext.SaveChanges();
            return player;
        }

        public void DeletePlayer(Player player)
        {
            _playerContext.Players.Remove(player);
            _playerContext.SaveChanges();
        }

        public Player EditPlayer(Player player)
        {
            var existingPlayer = _playerContext.Players.Find(player.Id);
            if(existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                _playerContext.Players.Update(existingPlayer);
                _playerContext.SaveChanges();
            }
            return player;
        }

        public Player GetPlayer(Guid Id)
        {
            var player = _playerContext.Players.Find(Id);
            return player;
        }

        public List<Player> GetPlayers()
        {
            return _playerContext.Players.ToList();
        }
    }
}

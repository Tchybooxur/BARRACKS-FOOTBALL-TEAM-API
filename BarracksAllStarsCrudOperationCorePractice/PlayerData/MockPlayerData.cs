using BarracksAllStarsCrudOperationCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksAllStarsCrudOperationCorePractice.PlayerData
{

    public class MockPlayerData : IPlayerData
    {
        private List<Player> players = new List<Player>()
    {
        new Player()
        {
            Id = Guid.NewGuid(),
            Name = "Yoruba Messi"
        },

        new Player()
        {
            Id = Guid.NewGuid(),
            Name = "Bubu"
        }
    };
        public Player AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid();
            players.Add(player);
            return player;
        }

        public void DeletePlayer(Player player)
        {
            players.Remove(player);
        }

        public Player EditPlayer(Player player)
        {
            var existing_player = GetPlayer(player.Id);
            existing_player.Name = player.Name;
            return existing_player;
        }

        public Player GetPlayer(Guid Id)
        {
            return players.SingleOrDefault(player => player.Id == Id);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}

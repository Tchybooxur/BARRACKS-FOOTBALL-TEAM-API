using BarracksAllStarsCrudOperationCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksAllStarsCrudOperationCorePractice.PlayerData
{
    public interface IPlayerData
    {
        List<Player> GetPlayers();

        Player GetPlayer(Guid Id);

        Player AddPlayer(Player player);

        void DeletePlayer(Player player);

        Player EditPlayer(Player player);
    }
}

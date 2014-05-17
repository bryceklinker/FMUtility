using FMEditorLive.FMObjects;
using FMUtility.Data.Proxies;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface IPlayerModelMapper
    {
        PlayerModel Map(Player player);
    }

    public class PlayerModelMapper : IPlayerModelMapper
    {
        public PlayerModel Map(Player player)
        {
            return new PlayerModelProxy(player)
            {
                CurrentAbility = player.CurrentAbility,
                FirstName = player.FirstName,
                Id = player.ID,
                LastName = player.LastName,
                PotentialAbility = player.PotentialAbility
            };
        }
    }
}
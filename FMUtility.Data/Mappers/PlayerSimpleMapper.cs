using FMUtility.Models;
using FMUtility.Models.Dtos;

namespace FMUtility.Data.Mappers
{
    public interface IPlayerSimpleMapper
    {
        PlayerSimple Map(PlayerModel player);
    }

    public class PlayerSimpleMapper : IPlayerSimpleMapper
    {
        public PlayerSimple Map(PlayerModel player)
        {
            return new PlayerSimple
            {
                ClubId = player.ClubId,
                ClubName = player.ClubName,
                CurrentAbility = player.CurrentAbility,
                FirstName = player.FirstName,
                Id = player.Id,
                LastName = player.LastName,
                PotentialAbility = player.PotentialAbility
            };
        }
    }
}

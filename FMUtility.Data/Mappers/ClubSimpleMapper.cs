using FMUtility.Models;
using FMUtility.Models.Dtos;

namespace FMUtility.Data.Mappers
{
    public interface IClubSimpleMapper
    {
        ClubSimple Map(ClubModel club);
    }

    public class ClubSimpleMapper : IClubSimpleMapper
    {
        public ClubSimple Map(ClubModel club)
        {
            return new ClubSimple
            {
                Id = club.Id,
                Morale = club.Morale,
                Name = club.Name,
                Reputation = club.Reputation,
                YearFounded = club.YearFounded
            };
        }
    }
}

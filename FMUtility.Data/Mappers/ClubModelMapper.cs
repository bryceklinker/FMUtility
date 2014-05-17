using FMEditorLive;
using FMUtility.Data.Proxies;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface IClubModelMapper
    {
        ClubModel Map(Club club);
    }

    public class ClubModelMapper : IClubModelMapper
    {
        public ClubModel Map(Club club)
        {
            return new ClubModelProxy(club)
            {
                AverageAttendance = club.AvgAttendance,
                ChairmanStatus = club.ChairmanStatus,
                Id = club.ID,
                MaximumAttendance = club.MaxAttendance,
                MinimumAttendance = club.MinAttendance,
                Morale = club.ClubMorale,
                Name = club.Name,
                Reputation = club.Reputation,
                TrainingFacilities = club.TrainingFacilities,
                YearFounded = club.YearFounded,
                YouthFacilities = club.YouthFacilities,
                YouthRecruitment = club.YouthRecruitment
            };
        }
    }
}
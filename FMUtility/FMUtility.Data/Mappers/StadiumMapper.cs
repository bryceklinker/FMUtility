using FMEditorLive;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface IStadiumMapper
    {
        StadiumModel Map(Stadium stadium);
    }

    public class StadiumMapper : IStadiumMapper
    {
        public StadiumModel Map(Stadium stadium)
        {
            return new StadiumModel
            {
                BuildDate = stadium.BuildDate,
                Capacity = stadium.Capacity,
                ExpansionCapacity = stadium.ExpansionCapacity,
                Name = stadium.Name,
                PitchCondition = stadium.PitchCondition,
                SeatingCapacity = stadium.SeatingCapacity
            };
        }
    }
}
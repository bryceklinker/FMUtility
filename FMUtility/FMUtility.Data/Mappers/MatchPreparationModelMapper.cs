using FMEditorLive;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface IMatchPreparationModelMapper
    {
        MatchPreparationModel Map(MatchPreparation matchPreparation);
    }

    public class MatchPreparationModelMapper : IMatchPreparationModelMapper
    {
        public MatchPreparationModel Map(MatchPreparation matchPreparation)
        {
            return new MatchPreparationModel
            {
                ClosingDown = matchPreparation.ClosingDown,
                CreativeFreedom = matchPreparation.CreativeFreedom,
                Formation = matchPreparation.Formation,
                Marking = matchPreparation.Marking,
                Mentality = matchPreparation.Mentality,
                PassingStyle = matchPreparation.PassingStyle,
                Tempo = matchPreparation.Tempo,
                Width = matchPreparation.Width
            };
        }
    }
}
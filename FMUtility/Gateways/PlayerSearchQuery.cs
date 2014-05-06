using FMUtility.Eventing.Args;
using FMUtility.Models;

namespace FMUtility.Gateways
{
    public class PlayerSearchQuery : IQuery<PlayerModel>
    {
        private readonly PlayerSearchArgs _playerSearchArgs;

        public PlayerSearchQuery(PlayerSearchArgs playerSearchArgs)
        {
            _playerSearchArgs = playerSearchArgs;
        }

        public bool IsMatch(PlayerModel model)
        {
            return IsMatchingCurrentAbility(model.CurrentAbility)
                   && (IsMatchingName(model.FirstName) || IsMatchingName(model.LastName))
                   && IsMatchingPotentialAbility(model.PotentialAbility);
        }

        private bool IsMatchingName(string name)
        {
            if (string.IsNullOrWhiteSpace(_playerSearchArgs.Name))
                return true;

            if (string.IsNullOrWhiteSpace(name))
                return false;

            return name.ToLowerInvariant().Contains(_playerSearchArgs.Name.ToLowerInvariant());
        }

        private bool IsMatchingCurrentAbility(int currentAbility)
        {
            return IsMatchingAbility(_playerSearchArgs.CurrentAbility, currentAbility);
        }

        private bool IsMatchingPotentialAbility(int potentialAbility)
        {
            return IsMatchingAbility(_playerSearchArgs.PotentialAbility, potentialAbility);
        }

        private bool IsMatchingAbility(int? criteria, int ability)
        {
            if (criteria.GetValueOrDefault(0) == 0)
                return true;

            return criteria.Value <= ability;
        }
    }
}

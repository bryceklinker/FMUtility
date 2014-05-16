using System;
using FMUtility.Core.Eventing.Args;
using FMUtility.Models;

namespace FMUtility.Data.Queries
{
    public class ClubSearchQuery : IQuery<ClubModel>
    {
        private readonly ClubSearchArgs _clubSearchArgs;

        public ClubSearchQuery(ClubSearchArgs clubSearchArgs)
        {
            _clubSearchArgs = clubSearchArgs;
        }

        public bool IsMatch(ClubModel model)
        {
            return IsMatchingReputation(model.Reputation)
                   && IsMatchingName(model.Name);
        }

        private bool IsMatchingName(string name)
        {
            if (string.IsNullOrWhiteSpace(_clubSearchArgs.Name))
                return true;

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return name.ToLowerInvariant().Contains(_clubSearchArgs.Name.ToLowerInvariant());
        }

        private bool IsMatchingReputation(int reputation)
        {
            if (_clubSearchArgs.Reputation.GetValueOrDefault(0) == 0)
                return true;

            return _clubSearchArgs.Reputation.GetValueOrDefault() <= reputation;
        }
    }
}

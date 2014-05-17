using System;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class TeamTypeExtensions
    {
        public static TeamType AsTeamType(this FMEditorLive.FMObjects.TeamType teamType)
        {
            return (TeamType) Enum.Parse(typeof (TeamType), teamType.ToString());
        }
    }
}
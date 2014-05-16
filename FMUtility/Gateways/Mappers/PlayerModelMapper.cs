using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FMEditorLive.FMObjects;
using FMUtility.Extensions;
using FMUtility.Models;
using Humanizer;

namespace FMUtility.Gateways.Mappers
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

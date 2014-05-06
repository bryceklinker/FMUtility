using System.Collections.Generic;
using FMUtility.Models;

namespace FMUtility.Gateways
{
    public interface IFmContext
    {
        List<PlayerModel> Players { get; }
    }
}

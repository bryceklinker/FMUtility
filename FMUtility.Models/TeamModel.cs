using System.Collections.Generic;

namespace FMUtility.Models
{
    public class TeamModel
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string Name { get; set; }
        public int Reputation { get; set; }
        public TeamType TeamType { get; set; }
        public int TypeTypeNum { get; set; }

        public ClubModel Club { get; set; }
        public virtual List<MatchPreparationModel> MatchPreparations { get; set; }
        public virtual StadiumModel StadiumModel { get; set; }
        public virtual List<PlayerModel> Players { get; set; }
    }
}
using System.Collections.Generic;

namespace FMUtility.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PotentialAbility { get; set; }
        public int CurrentAbility { get; set; }

        public List<AttributeModel> Techincal { get; set; }
        public List<AttributeModel> Hidden { get; set; }
        public List<AttributeModel> Mental { get; set; }
        public List<AttributeModel> Physical { get; set; }
        public List<AttributeModel> GoalKeeping { get; set; }
    }
}

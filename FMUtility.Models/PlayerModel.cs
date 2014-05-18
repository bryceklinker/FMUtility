using System;
using System.Collections.Generic;
using System.Linq;

namespace FMUtility.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PotentialAbility { get; set; }
        public int CurrentAbility { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }

        public string Position
        {
            get
            {
                if (Positions == null)
                    return null;

                var positions = Positions.Where(p => p.Value >= 15).Select(p => p.Name);
                return String.Join(", ", positions);
            }
        }

        public virtual List<Position> Positions { get; set; }

        public virtual List<AttributeModel> Techincal { get; set; }
        public virtual List<AttributeModel> Hidden { get; set; }
        public virtual List<AttributeModel> Mental { get; set; }
        public virtual List<AttributeModel> Physical { get; set; }
        public virtual List<AttributeModel> GoalKeeping { get; set; }
    }
}
using System.Collections.Generic;

namespace FMUtility.Models
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PotentialAbility { get; set; }
        public int CurrentAbility { get; set; }
        
        public List<Position> Positions { get; set; } 

        public List<PlayingAttribute> Attacking { get; set; }
        public List<PlayingAttribute> Defending { get; set; }
        public List<PlayingAttribute> Technical { get; set; }
        public List<PlayingAttribute> Physical { get; set; }
        public List<PlayingAttribute> Mental { get; set; }
        public List<PlayingAttribute> Hidden { get; set; } 
    }
}

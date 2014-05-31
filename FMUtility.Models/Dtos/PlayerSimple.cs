namespace FMUtility.Models.Dtos
{
    public class PlayerSimple
    {
        public int Id { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentAbility { get; set; }
        public int PotentialAbility { get; set; }
        public string ClubName { get; set; }
        public int ClubId { get; set; }
    }
}

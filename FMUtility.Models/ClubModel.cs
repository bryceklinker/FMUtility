using System.Collections.Generic;

namespace FMUtility.Models
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrainingFacilities { get; set; }
        public int YouthRecruitment { get; set; }
        public int YouthFacilities { get; set; }
        public int MaximumAttendance { get; set; }
        public int MinimumAttendance { get; set; }
        public int AverageAttendance { get; set; }
        public int Reputation { get; set; }
        public int Morale { get; set; }
        public int YearFounded { get; set; }
        public int ChairmanStatus { get; set; }

        public virtual FinancesModel Finances { get; set; }
        public virtual List<KitModel> Kits { get; set; }
        public virtual List<TeamModel> Teams { get; set; }
    }
}
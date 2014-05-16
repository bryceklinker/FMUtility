using System;

namespace FMUtility.Models
{
    public class StadiumModel
    {
        public DateTime BuildDate { get; set; }
        public int Capacity { get; set; }
        public int ExpansionCapacity { get; set; }
        public string Name { get; set; }
        public int PitchCondition { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
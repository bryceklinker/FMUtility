namespace FMUtility.Models
{
    public class KitModel
    {
        public ColorModel Background { get; set; }
        public ColorModel Foreground { get; set; }
        public KitType KitType { get; set; }
        public ColorModel NumberColor { get; set; }
        public bool IsOutfieldPlayer { get; set; }
        public ColorModel Outline { get; set; }
        public ColorModel OutlineNumberColor { get; set; }
        public RecordType RecordType { get; set; }
        public int Style { get; set; }
    }
}
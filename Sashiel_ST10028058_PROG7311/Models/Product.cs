namespace Sashiel_ST10028058_PROG7311.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ImagePath { get; set; } 

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}

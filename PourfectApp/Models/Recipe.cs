using SQLite;

namespace PourfectApp.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Method { get; set; } // V60, Chemex, etc.
        public double CoffeeWeight { get; set; }
        public double WaterWeight { get; set; }
        public int Temperature { get; set; }
        public string TotalTime { get; set; }
        public string GrindSize { get; set; }
        public string Steps { get; set; } // JSON or formatted text for step-by-step
        public bool IsFavorite { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } // Username

        // Calculated properties
        public string Ratio => CoffeeWeight > 0 ? $"1:{WaterWeight / CoffeeWeight:F1}" : "N/A";
        public string FavoriteIcon => IsFavorite ? "⭐" : "☆";
    }
}
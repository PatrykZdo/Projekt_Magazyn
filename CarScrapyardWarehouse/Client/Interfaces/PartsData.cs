using CarScrapyardWarehouse.Shared.Models;

namespace CarScrapyardWarehouse.Client.Interfaces
{
    public class PartsData
    {
        public int Id { get; set; }
        public string Part { get; set; }
        public string Warehouse { get; set; }
        public string Area { get; set; }
        public string Position { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public List<PartImage> PartImages { get; set; }
    }
}

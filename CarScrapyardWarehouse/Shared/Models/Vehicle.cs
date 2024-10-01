namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Parts = new HashSet<Part>();
            VehicleAttributeValues = new HashSet<VehicleAttributeValue>();
            VehicleImages = new HashSet<VehicleImage>();
        }

        public int Id { get; set; }
        public int IdType { get; set; }
        public string Vin { get; set; }
        public DateTime InsertDate { get; set; }
        public string User { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public double? PurchasePrice { get; set; }
        public bool? Archived { get; set; } = false;

        public virtual VehiclesType IdTypeNavigation { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<VehicleAttributeValue> VehicleAttributeValues { get; set; }
        public virtual ICollection<VehicleImage> VehicleImages { get; set; }
    }
}

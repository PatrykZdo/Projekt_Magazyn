namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class VehiclesType
    {
        public VehiclesType()
        {
            VehicleTypeAttributes = new HashSet<VehicleTypeAttribute>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<VehicleTypeAttribute> VehicleTypeAttributes { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

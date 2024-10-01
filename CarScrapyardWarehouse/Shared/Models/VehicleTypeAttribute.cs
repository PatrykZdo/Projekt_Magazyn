namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class VehicleTypeAttribute
    {
        public int Id { get; set; }
        public int IdAttribute { get; set; }
        public int IdVehiclesType { get; set; }
        public int OrderNumber { get; set; }

        public virtual Attribute IdAttributeNavigation { get; set; }
        public virtual VehiclesType IdVehiclesTypeNavigation { get; set; }
    }
}

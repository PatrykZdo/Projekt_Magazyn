namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class VehicleAttributeValue
    {
        public VehicleAttributeValue() { }
        public VehicleAttributeValue(int idAtrribute, string Value) { 
            this.IdAttribute = idAtrribute;
            this.Value = Value;
        }

        public int Id { get; set; }
        public int IdVehicle { get; set; }
        public int IdAttribute { get; set; }
        public string Value { get; set; }

        public virtual Attribute IdAttributeNavigation { get; set; }
        public virtual Vehicle IdVehicleNavigation { get; set; }
    }
}

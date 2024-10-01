namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            VehicleAttributeValues = new HashSet<VehicleAttributeValue>();
            VehicleTypeAttributes = new HashSet<VehicleTypeAttribute>();
        }

        public int Id { get; set; }
        public string AttriburteName { get; set; }
        public string DefaultValue { get; set; }
        public string StaticValues { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<VehicleAttributeValue> VehicleAttributeValues { get; set; }
        public virtual ICollection<VehicleTypeAttribute> VehicleTypeAttributes { get; set; }
    }
}

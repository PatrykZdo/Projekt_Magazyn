namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class VehicleImage
    {
        public int Id { get; set; }
        public int IdVehicle { get; set; }
        public int IdImage { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual Image IdImageNavigation { get; set; }
        public virtual Vehicle IdVehicleNavigation { get; set; }
    }
}

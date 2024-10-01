namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Image
    {
        public Image()
        {
            PartImages = new HashSet<PartImage>();
            VehicleImages = new HashSet<VehicleImage>();
        }

        public int Id { get; set; }
        public byte[] Image1 { get; set; }

        public virtual ICollection<PartImage> PartImages { get; set; }
        public virtual ICollection<VehicleImage> VehicleImages { get; set; }
    }
}

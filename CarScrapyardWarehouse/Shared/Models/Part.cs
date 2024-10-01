namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Part
    {
        public Part()
        {
            PartImages = new HashSet<PartImage>();
        }

        public int Id { get; set; }
        public int? IdVehicle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsWaste { get; set; }
        public string User { get; set; }
        public int IdPosition { get; set; }
        public int? IdCategory { get; set; } 
        public double? Price { get; set; }
        public bool? Archived { get; set; } = false;

        public virtual Position IdPositionNavigation { get; set; }
        public virtual Vehicle IdVehicleNavigation { get; set; }
        public virtual ICollection<PartImage> PartImages { get; set; }
        public virtual PartsCategory IdPartCategoryNavigation { get; set; }

		public override string ToString()
        {
            return $"{Id},{IdVehicle},{Name},{Description},{InsertDate},{IsWaste},{User},{IdPosition}";
        }
    }
}

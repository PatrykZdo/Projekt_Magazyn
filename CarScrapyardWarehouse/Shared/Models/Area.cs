namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Area
    {
        public Area()
        {
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }
        public int IdWarehouse { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }

        public virtual Warehouse IdWarehouseNavigation { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}

namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Areas = new HashSet<Area>();
        }

        public int Id { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}

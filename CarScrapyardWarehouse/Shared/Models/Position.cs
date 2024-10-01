namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class Position
    {
        public Position()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public int IdArea { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}

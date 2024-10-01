namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class PartsCategory
    {
        public PartsCategory()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}

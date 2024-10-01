namespace CarScrapyardWarehouse.Shared.Models
{
    public partial class PartImage
    {
        public int Id { get; set; }
        public int IdPart { get; set; }
        public int IdImage { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual Image IdImageNavigation { get; set; }
        public virtual Part IdPartNavigation { get; set; }
    }
}

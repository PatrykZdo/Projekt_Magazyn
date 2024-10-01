using static MudBlazor.CategoryTypes;

namespace CarScrapyardWarehouse.Client.Interfaces
{
    public class WholeObject
    {
        public string Code { get; set; }

        public Data data { get; set; }
    }
    public class Data
    {
        public ProductSet[] productSet { get; set; }
        public SellingMode sellingMode { get; set; }

        public string? name { get; set; }
        public Stock stock { get; set; }

        public Description description { get; set; }
    }

    public class ProductSet
    {
        public Product product { get; set; }
    }

    public class Description
    {
        public List<Section> sections { get; set; }
    }

    public class Item
    {
        public string type { get; set; }
        public string content { get; set; }
    }

    public class Section
    {
        public List<Item> items { get; set; }
    }

    public class Product
    {
        public string id { get; set; }

        public List<string> images { get; set; }

    }

    public class SellingMode
    {
        public Price price { get; set; }
    }

    public class Price
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Stock
    {
        public int available { get; set; }
    }
}


namespace arabi2.Models
{
    public class JsonModel
    {
        public class ProductDetails
        {
            public string success { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public items[] items { get; set; }
        }

        public class items
        {
            public int id { get; set; }
            public string title { get; set; }
            public string brand { get; set; }
            public categories[] categories { get; set; }
            public string price { get; set; }
            public string quantity { get; set; }
        }

        public class categories
        {
            public int id { get; set; }
            public string title { get; set; }
        }
    }
}

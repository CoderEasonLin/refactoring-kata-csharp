namespace RefactoringKata
{
    public class Product : IJsonString
    {
        public string Code { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = (Color)color;
            Size = (Size)size;
            Price = price;
            Currency = currency;
        }

        public string GetJsonString()
        {
            var jsonObject = new JsonBuilder();
            jsonObject.AddProperty("code", Code);
            jsonObject.AddProperty("color", Color.GetTypeText());
            if (Size != Size.SizeNotApplicable)
            {
                jsonObject.AddProperty("size", Size.GetTypeText());
            }
            jsonObject.AddProperty("price", Price);
            jsonObject.AddProperty("currency", Currency);

            return jsonObject.GetJsonString();
        }
    }
}

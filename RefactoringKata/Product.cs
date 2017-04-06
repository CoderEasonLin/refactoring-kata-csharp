namespace RefactoringKata
{
    public class Product : IJsonString
    {
        public string Code { get; set; }
        public int Color { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = (Size)size;
            Price = price;
            Currency = currency;
        }

        public string GetJsonString()
        {
            var jsonObject = new JsonObject();
            jsonObject.AddProperty("code", Code);
            jsonObject.AddProperty("color", GetColorFor());
            if (Size != Size.SizeNotApplicable)
            {
                jsonObject.AddProperty("size", Size.GetTypeText());
            }
            jsonObject.AddProperty("price", Price);
            jsonObject.AddProperty("currency", Currency);

            return jsonObject.GetJsonString();
        }

        private string GetColorFor()
        {
            switch (Color)
            {
                case 1:
                    return "blue";
                case 2:
                    return "red";
                case 3:
                    return "yellow";
                default:
                    return "no color";
            }
        }
    }
}

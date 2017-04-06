namespace RefactoringKata
{
    public class Product : IJsonString
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        public string Code { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        public string GetJsonString()
        {
            var jsonObject = new JsonObject();
            jsonObject.AddProperty("code", Code);
            jsonObject.AddProperty("color", GetColorFor());
            if (Size != Product.SIZE_NOT_APPLICABLE)
            {
                jsonObject.AddProperty("size", GetSizeFor());
            }
            jsonObject.AddProperty("price", Price);
            jsonObject.AddProperty("currency", Currency);

            return jsonObject.GetJsonString();
        }

        private string GetSizeFor()
        {
            switch (Size)
            {
                case 1:
                    return "XS";
                case 2:
                    return "S";
                case 3:
                    return "M";
                case 4:
                    return "L";
                case 5:
                    return "XL";
                case 6:
                    return "XXL";
                default:
                    return "Invalid Size";
            }
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

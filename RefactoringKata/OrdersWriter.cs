using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                sb.Append("{");

                sb.Append(GetJsonProperty("id", order.GetOrderId()));
                sb.Append("\"products\": [");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    var product = order.GetProduct(j);
                    var jsonObject = new JsonObject();
                    jsonObject.AddProperty("code", product.Code);
                    jsonObject.AddProperty("color", getColorFor(product));
                    if (product.Size != Product.SIZE_NOT_APPLICABLE)
                    {
                        jsonObject.AddProperty("size", getSizeFor(product));
                    }
                    jsonObject.AddProperty("price", product.Price);
                    jsonObject.AddProperty("currency", product.Currency);

                    sb.Append(jsonObject.GetJsonString());
                }

                if (order.GetProductsCount() > 0)
                {
                    sb.Remove(sb.Length - 2, 2);
                }

                sb.Append("]");
                sb.Append("}, ");
            }

            if (_orders.GetOrdersCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.Append("]}").ToString();
        }

        private string GetJsonProperty(string name, double value)
        {
            return string.Format("\"{0}\": {1}, ", name, value);
        }

        private string getSizeFor(Product product)
        {
            switch (product.Size)
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

        private string getColorFor(Product product)
        {
            switch (product.Color)
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

    public class JsonObject
    {
        public StringBuilder sb = new StringBuilder();

        public JsonObject()
        {
            sb = new StringBuilder();
            sb.Append("{");
        }

        public void AddProperty(string name, string value)
        {
            sb.Append(GetJsonProperty(name, value));
        }

        public void AddProperty(string name, double value)
        {
            sb.Append(GetJsonProperty(name, value));
        }


        private string GetJsonProperty(string name, string value)
        {
            return string.Format("\"{0}\": \"{1}\", ", name, value);
        }

        private string GetJsonProperty(string name, double value)
        {
            return string.Format("\"{0}\": {1}, ", name, value);
        }

        public string GetJsonString()
        {
            sb.Remove(sb.Length - 2, 2);
            sb.Append("}, ");
            return sb.ToString();
        }
    }
}
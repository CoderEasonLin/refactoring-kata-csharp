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
                    sb.Append(product.GetJsonString());
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
    }

    public class JsonObject
    {
        public StringBuilder Sb;

        public JsonObject()
        {
            Sb = new StringBuilder();
            Sb.Append("{");
        }

        public void AddProperty(string name, string value)
        {
            Sb.Append(GetJsonProperty(name, value));
        }

        public void AddProperty(string name, double value)
        {
            Sb.Append(GetJsonProperty(name, value));
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
            Sb.Remove(Sb.Length - 2, 2);
            Sb.Append("}, ");
            return Sb.ToString();
        }
    }
}
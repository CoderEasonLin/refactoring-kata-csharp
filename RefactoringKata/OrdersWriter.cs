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
            var jsonObject = new JsonObject();
            jsonObject.AddArray("orders", _orders.GetOrders());
            var jsonString = jsonObject.GetJsonString();
            jsonString = jsonString.Substring(0, jsonString.Length - 2);
            return jsonString;
        }
    }
}
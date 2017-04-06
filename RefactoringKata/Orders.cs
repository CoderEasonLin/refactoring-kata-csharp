using System.Collections.Generic;

namespace RefactoringKata
{
    public class Orders : IJsonObject
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public int GetOrdersCount()
        {
            return _orders.Count;
        }

        public Order GetOrder(int i)
        {
            return _orders[i];
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public string GetJsonString()
        {
            var jsonObject = new JsonObject();
            jsonObject.AddArray("orders", _orders);
            var jsonString = jsonObject.GetJsonString();
            jsonString = jsonString.Substring(0, jsonString.Length - 2);
            return jsonString;
        }
    }
}

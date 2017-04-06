using System.Collections.Generic;

namespace RefactoringKata
{
    public class Orders : IJsonString
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

        public string GetJsonString()
        {
            var jsonObject = new JsonObject();
            jsonObject.AddArray("orders", _orders);
            return jsonObject.GetJsonString();
        }
    }
}

using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
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
            AddCommaIfNeed();
            Sb.Append(GetJsonProperty(name, value));
        }

        public void AddProperty(string name, double value)
        {
            AddCommaIfNeed();
            Sb.Append(GetJsonProperty(name, value));
        }

        private string GetJsonProperty(string name, string value)
        {
            return string.Format("\"{0}\": \"{1}\"", name, value);
        }

        private string GetJsonProperty(string name, double value)
        {
            return string.Format("\"{0}\": {1}", name, value);
        }

        public string GetJsonString()
        {
            Sb.Append("}");
            return Sb.ToString();
        }

        public void AddArray<T>(string name, List<T> values) where T : IJsonString
        {
            AddCommaIfNeed();
            Sb.Append(string.Format("\"{0}\": [", name));
            foreach (var value in values)
            {
                AddCommaIfNeed();
                Sb.Append(value.GetJsonString());
            }
            Sb.Append("]");
        }

        private void AddCommaIfNeed()
        {
            var s = Sb.ToString();

            if (!s.EndsWith("{") &&
                !s.EndsWith("[") &&
                !s.EndsWith(", "))
                Sb.Append(", ");
        }
    }
}
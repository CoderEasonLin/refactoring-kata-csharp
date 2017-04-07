using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class JsonBuilder
    {
        public StringBuilder Sb;

        public JsonBuilder()
        {
            Sb = new StringBuilder();
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
            return string.Format("{{{0}}}", Sb);
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
                !s.EndsWith(", ") &&
                !string.IsNullOrEmpty(s))
                Sb.Append(", ");
        }
    }
}
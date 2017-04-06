using System;

namespace RefactoringKata
{
    public static class EnumExtensions
    {
        public static string GetTypeText(this Enum value)
        {
            var type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            var field = type.GetField(name);
            if (field == null)
            {
                return null;
            }

            var attr = Attribute.GetCustomAttribute(field, typeof(TypeTextAttribute)) as TypeTextAttribute;
            if (attr == null)
            {
                return null;
            }

            return attr.TypeText;
        }
    }
}
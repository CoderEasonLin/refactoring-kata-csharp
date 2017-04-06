using System;

namespace RefactoringKata
{
    public enum Size
    {
        SizeNotApplicable = -1,

        [TypeText("Invalid Size")]
        InvalidSize = 0,

        [TypeText("XS")]
        XS = 1,

        [TypeText("S")]
        S,

        [TypeText("M")]
        M,

        [TypeText("L")]
        L,

        [TypeText("XL")]
        XL,

        [TypeText("XXL")]
        XXL
    }

    public class TypeTextAttribute : Attribute
    {
        public string TypeText;
        public TypeTextAttribute(string typeText) { TypeText = typeText; }
    }
}
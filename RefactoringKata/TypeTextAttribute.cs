﻿using System;

namespace RefactoringKata
{
    public class TypeTextAttribute : Attribute
    {
        public string TypeText;
        public TypeTextAttribute(string typeText) { TypeText = typeText; }
    }
}
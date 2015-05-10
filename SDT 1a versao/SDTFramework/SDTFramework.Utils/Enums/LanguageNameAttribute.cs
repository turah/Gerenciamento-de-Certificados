using System;

namespace SDTFramework.Utils.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class LanguageNameAttribute : Attribute
    {
        public string LanguageName { get; private set; }

        public LanguageNameAttribute(string languageName)
        {
            LanguageName = languageName;
        }
    }
}
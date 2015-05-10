using System;

namespace SDTFramework.Utils.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AuditNomeKey : Attribute
    {
        public string Nome { get; private set; }

        public AuditNomeKey(string nome)
        {
            Nome = nome;
        }
    }
}

using System.Linq;

namespace SDTFramework.Utils.Enums
{
    public static class AuditEnumHelper
    {
        public static string AuditNomeKey(this AuditFunctionality value)
        {
            return GetNomeKey(value);
        }

        public static string AuditNomeKey(this AuditActionEnum value)
        {
            return GetNomeKey(value);
        }

        private static string GetNomeKey(object o)
        {
            var field = o.GetType().GetField(o.ToString());
            if (field == null) return o.ToString();
            var nomeAttribute = (AuditNomeKey)field.GetCustomAttributes(typeof(AuditNomeKey), false).FirstOrDefault();
            return nomeAttribute != null ? nomeAttribute.Nome : o.ToString();
        }

        public static bool NewEquals(this AuditFunctionality a, AuditFunctionality b)
        {
            return a.Equals(b) ||
                   a == AuditFunctionality.PublicacaoStatusProgramacaoNavio && b == AuditFunctionality.EdicaoStatusProgramacaoNavio ||
                   b == AuditFunctionality.PublicacaoStatusProgramacaoNavio && a == AuditFunctionality.EdicaoStatusProgramacaoNavio;
        }
    }
}
namespace SDTFramework.Utils.Exceptions
{
    public class RadixExceptionDTO
    {
        public string ClassName { get; set; }
        public string MehtodName { get; set; }
        public string Message { get; set; }
        public int Line { get; set; }

        public override string ToString()
        {
            return string.Format("Classe: {0}, Método: {1}, Linha: {2}, Mensagem: {3}", ClassName, MehtodName, Line, Message);
        }
    }
}

namespace WebApiProdutos.Src.Extensions
{
    public static class StringExtensions
    {
        public static string ToCaptalize(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.ToLower().Substring(1, str.Length - 1);
        }
    }
}

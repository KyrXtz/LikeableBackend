namespace Infrastructure.Extensions
{
    public static class Extensions
    {
        public static class GetDictionaryValue
        {
            public static string GetValue(Dictionary<string, string> dict, string propName)
            {
                return dict.GetValueOrDefault(propName) ?? "0";
            }
        }
    }
}

namespace SharedKernel
{
    public static class Extensions
    {
        //public static string GetValue(Dictionary<string, string> dict, string propName)
        //{
        //    return dict.GetValueOrDefault(propName) ?? "0";
        //}

        public static string GetId(this ClaimsPrincipal user)
            => user
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                ?.Value;
    }
}

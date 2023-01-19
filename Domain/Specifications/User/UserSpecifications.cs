namespace Domain.Specifications.User
{
    public static class UserSpecifications
    {
        public static async Task<Aggregates.User> GetUserByIdSpecification(this IAppDbContext<Aggregates.User> itemDbContext, string userId)
        {
            var user = await itemDbContext.EntitySet.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }
    }
}

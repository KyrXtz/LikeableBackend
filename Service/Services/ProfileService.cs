namespace Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IAppDbContext<User> _userDbContext;

        public ProfileService(IAppDbContext<User> userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<Result<GetProfileResponseModel>> ByUser(string userId)
        {
            var profile = await _userDbContext
                .EntitySet
                .Where(u => u.Id == userId)
                .Select(u => new GetProfileResponseModel
                {
                    Name = u.Profile.Name,
                    MainPhotoUrl = u.Profile.MainPhotoUrl,
                })
                .FirstOrDefaultAsync();

            return profile;
        }

        public async Task<Result<UpdateProfileResponseModel>> Update(
            string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl)
        {
            var user = await _userDbContext
                .EntitySet
                .Where(u => u.Id == userId)
                .Include(u => u.Profile)
                .FirstOrDefaultAsync();

            if(user == null) return "User does not exist.";

            var res = await ChangeEmail(user, userId, email);
            if (!res.Succeeded) return res.Error;

            res = await ChangeUserName(user, userId, userName);
            if (!res.Succeeded) return res.Error;

            ChangeProfile(user,name,mainPhotoUrl);

            await _userDbContext.SaveChangesAsync();

            return new UpdateProfileResponseModel
            {
                Updated = true
            };
        }

        private async Task<Result<bool>> ChangeEmail(User user,string userId, string email) //TODO check if result is correct
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await _userDbContext
                    .EntitySet
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists) return "The provided e-mail is already taken.";

                user.Email = email;
            }
            return true;
        }
        private async Task<Result<bool>> ChangeUserName(User user, string userId, string userName) //TODO check if result is correct
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await _userDbContext
                    .EntitySet
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists) return "The provided username is already taken.";

                user.UserName = userName;
            }
            return true;
        }
        private void ChangeProfile(User user,
            string name,
            string mainPhotoUrl)
        {
            if (user.Profile.Name != name)
            {
                //user.Profile.Name = name; //TODO Update profile of user
            }

            if (user.Profile.MainPhotoUrl != mainPhotoUrl)
            {
               //user.Profile.MainPhotoUrl = mainPhotoUrl;
            }
        }

    }
}

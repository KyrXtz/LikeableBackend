namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext<Item> _itemsDbContext;
        private readonly IAppDbContext<User> _usersDbContext;
        public UserService(IAppDbContext<Item> itemsDbContext,
            IAppDbContext<User> usersDbContext)
        {
            _itemsDbContext = itemsDbContext;
            _usersDbContext = usersDbContext;
        }

        public async Task<Result<GetUserNameResponseModel>> GetUserName(string userId)
        {
            var user = await _usersDbContext.GetUserByIdSpecification(userId);
            if (user == null) return "User not found";

            return new GetUserNameResponseModel
            {
                UserName = user.UserName
            };

        }

        public async Task<Result<LikedItemsResponseModel>> LikedItems(string userId)
        {
            var user = await _usersDbContext.EntitySet
                 .Include(x => x.LikedItems)
                 .FirstOrDefaultAsync(x => x.Id == userId);

            var likedItemIds = user.LikedItems.Select(x => x.Id);
            var likedItems = await _itemsDbContext.EntitySet
                .Where(x => likedItemIds.Contains(x.Id)).ToListAsync();

            return new LikedItemsResponseModel
            {
                Items = likedItems.Select(x => new LikedItemsResponseModel.Item
                {
                    Id = x.Id,
                    ImageUrl = x.Images.ImageList.FirstOrDefault()
                })
            };
        }
        public async Task<Result<GetProfileResponseModel>> GetProfile(string userId)
        {
            var profile = await _usersDbContext
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

        public async Task<Result<UpdateProfileResponseModel>> UpdateUserName(
            string userId,
            string userName)
        {
            var user = await _usersDbContext
                .EntitySet
                .Where(u => u.Id == userId)
                .Include(u => u.Profile)
                .FirstOrDefaultAsync();

            if (user == null) return "User does not exist.";

            //var res = await ChangeEmail(user, userId, email);
            //if (!res.Succeeded) return res.Error;

            var res = await ChangeUserName(user, userId, userName);
            if (!res.Succeeded) return res.Error;

            await _usersDbContext.SaveChangesAsync();

            return new UpdateProfileResponseModel
            {
                Updated = true
            };
        }
        public async Task<Result<UpdateProfileResponseModel>> UpdateProfile(
            string userId,
            string name,
            string mainPhotoUrl)
        {
            var user = await _usersDbContext
                .EntitySet
                .Where(u => u.Id == userId)
                .Include(u => u.Profile)
                .FirstOrDefaultAsync();

            if (user == null) return "User does not exist.";

            user.UpdateProfile(name, mainPhotoUrl);

            await _usersDbContext.SaveChangesAsync();

            return new UpdateProfileResponseModel
            {
                Updated = true
            };
        }

        private async Task<Result<bool>> ChangeEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await _usersDbContext
                    .EntitySet
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists) return "The provided e-mail is already taken.";

                user.Email = email;
            }
            return true;
        }
        private async Task<Result<bool>> ChangeUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await _usersDbContext
                    .EntitySet
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists) return "The provided username is already taken.";

                user.UserName = userName;
            }
            return true;
        }
    }
}

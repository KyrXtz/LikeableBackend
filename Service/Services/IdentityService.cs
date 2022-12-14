namespace Service.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;

        public IdentityService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        private string GenerateJwtToken(string userId, string username, string secret, string role)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userId),
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Result<RegisterUserResponseModel>> Register(string username, string password, string email)
        {
            var user = User.Create(username, email);

            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, Constants.Roles.User.ToString());

            return new RegisterUserResponseModel
            {
                Created = true
            };
        }

        public async Task<Result<LoginUserResponseModel>> Login(string userId, string username, string secret, string role)
        {
            return await Task.Run(() => new LoginUserResponseModel
            {
                Token = GenerateJwtToken(userId, username, secret, role)
            });
        }
    }
}

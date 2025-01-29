using AutoMapper;
using System.Text;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, IMapper mapper, TokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<(string Token, string Username)?> RegisterAsync(AddUserDTO userDTO)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDTO.Email);
            if (existingUser != null)
            {
                return null; // Користувач вже існує
            }

            var user = _mapper.Map<User>(userDTO);
            user.Password = HashPassword(userDTO.Password);

            await _userRepository.AddUserAsync(user);
            var token = _tokenGenerator.GenerateJwtToken(user);

            return (token, user.Username);
        }

        public async Task<(string Token, UserDTO User)?> LoginAsync(AddUserDTO userDTO)
        {
            var user = await _userRepository.GetByEmailAsync(userDTO.Email);
            if (user == null || !VerifyPassword(userDTO.Password, user.Password))
            {
                return null;
            }

            var token = _tokenGenerator.GenerateJwtToken(user);
            var userDto = _mapper.Map<UserDTO>(user);
            return (token, userDto);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha256 = SHA256.Create();
            var hashedInput = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashedInput == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }


}

using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.User;
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

        public async Task<(string Token, UserDTO User)?> RegisterAsync(AddUserDTO userDTO)
        {
            var existingUser = await _userRepository.FindOneAsync(x => x.Email == userDTO.Email);
            if (existingUser != null)
            {
                return null;
            }

            var user = _mapper.Map<User>(userDTO);
            user.Password = _userRepository.HashPassword(userDTO.Password);

            await _userRepository.AddAsync(user);
            
            var token = _tokenGenerator.GenerateJwtToken(user);
            var userDTOResult = _mapper.Map<UserDTO>(user);

            return (token, userDTOResult);
        }

        public async Task<(string Token, UserDTO User)?> LoginAsync(AddUserDTO userDTO)
        {
            var user = await _userRepository.GetByEmailAndPassword(userDTO.Email, userDTO.Password);
            
            if (user == null)
            {
                return null;
            }

            var token = _tokenGenerator.GenerateJwtToken(user);
            var userDto = _mapper.Map<UserDTO>(user);
            return (token, userDto);
        }
    }
}

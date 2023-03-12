using Application.Models;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infastructure.Repositories.Interfaces;
using System.Security.Cryptography;

namespace Application.Services
{
    public class UserControlService : IUserControlService
    {
        private readonly IUserControlRepository _userControlRepository;
        private readonly IMapper _mapper;

        public UserControlService(IUserControlRepository userControlRepository, IMapper mapper)
        {
            _userControlRepository = userControlRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _userControlRepository.GetUserAsync(id, cancellationToken);  

            if (user == null) 
            {
                throw new ArgumentException(nameof(user));
            }

            return user;
        }

        public async Task<string> LoginAsync(Login login, CancellationToken cancellationToken)
        {
            if(login is null)
            {
                throw new ArgumentNullException(nameof(login)); 
            }

            var usersFromDb = await _userControlRepository.GetUsersAsync(cancellationToken);

            if (usersFromDb == null) 
            {
                throw new ArgumentException("We not have any users!!!");
            }

            var currentUser = usersFromDb.FirstOrDefault(x => x.Login == login.LoginUser 
                && VerifyHashedPassword(x.Password, login.Password));

            if(currentUser == null) 
            {
                throw new ArgumentException("Bad password or login!");
            }

            return "token";
        }

        public async Task<Login> RegisterAsync(Register user, CancellationToken cancellationToken)
        {
            if(user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Password = HashPassword(user.Password);

            var registredUser = await _userControlRepository.CreateUserAsync(_mapper.Map<User>(user), cancellationToken);

            if (registredUser is null) 
            {
                throw new ArgumentNullException(nameof(user));
            }

            return _mapper.Map<Login>(user);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
    }
}

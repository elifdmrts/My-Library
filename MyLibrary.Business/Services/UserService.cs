using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyLibrary.Data;
using MyLibrary.Data.Dto;
using MyLibrary.Data.Entities;
using MyLibrary.Data.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyLibrary.Business.Services
{
    public interface IUserService
    {
        User CreateUser(UserCreateDto model);
        User Register(RegisterDto model);
        string Login(LoginDto model);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly JwtModel _jwt;


        public UserService(AppDbContext context, IOptions<JwtModel> jwt
)
        {
            _context = context;
            _jwt = jwt.Value;
        }

        public User CreateUser(UserCreateDto model)
        {
            try
            {
                if (!model.Password.Equals(model.RePassword))
                {
                    throw new Exception("Şifreler uyuşmamaktadır.");
                }

                var isExistUser = _context.Users.Any(x => x.Email == model.Email && !x.Deleted);

                if (isExistUser)
                {
                    throw new Exception("Email adresi ile daha önce kullanıcı bulunmaktadır.");
                }

                if (model.Password.Length < 6)
                {
                    throw new Exception("Şifre en az 6 karakter olmalıdır.");
                }

                var user = new User
                {
                    IsActive = model.IsActive,
                    Password = model.Password, //TODO: Şifreleri hash le
                    CreatedDate = DateTime.Now,
                    Deleted = false,
                    Email = model.Email,
                    Name = model.Name,
                    Phone = model.Phone,
                    Surname = model.Surname,
                    UserType = UserTypes.Admin
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Register(RegisterDto model)
        {
            try
            {
                if (!model.Password.Equals(model.RePassword))
                {
                    throw new Exception("Şifreler uyuşmamaktadır.");
                }

                var isExistUser = _context.Users.Any(x => x.Email == model.Email && !x.Deleted);

                if (isExistUser)
                {
                    throw new Exception("Email adresi ile daha önce kullanıcı bulunmaktadır.");
                }

                if (model.Password.Length < 6)
                {
                    throw new Exception("Şifre en az 6 karakter olmalıdır.");
                }

                var hashedPassword = HashPassword(model.Password);

                var user = new User
                {
                    IsActive = true,
                    Password = hashedPassword, //TODO: Şifreleri hash le***
                    CreatedDate = DateTime.Now,
                    Deleted = false,
                    Email = model.Email,
                    Name = model.Name,
                    Phone = model.Phone,
                    Surname = model.Surname,
                    UserType = UserTypes.User
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                //TODO : kullanıcıya email gönder 

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Login(LoginDto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                {
                    throw new Exception("Email ve şifre boş olamaz.");
                }

                // TODO: db de password hash lenirse şifre kontrolü de hashlenecek****
                // var hashedPassword = HashedPassword(model.Password);*****

                var hashedPassword = HashPassword(model.Password);

                var user = _context.Users.FirstOrDefault(x => !x.Deleted && x.IsActive && x.Email == model.Email && x.Password == hashedPassword);

                if (user is null)
                {
                    throw new Exception("Email adresi veya şifre hatalıdır.");
                }
                var token = NewToken(user.Id);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public string NewToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", userId.ToString())
                }),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        private string HashPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));

            }
            return builder.ToString();
        }
    }
}

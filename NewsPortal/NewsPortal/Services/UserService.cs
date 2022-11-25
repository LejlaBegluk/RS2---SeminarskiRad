using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Model.Enums;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class UserService : CRUDService<MUser, UserSearchRequest, User, UserUpsertRequest, UserUpsertRequest>, IUserService
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public UserService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  override IEnumerable<MUser> Get(UserSearchRequest search)
        {
            var query = _context.Users.Include(x => x.Role).AsQueryable().OrderBy(c => c.FirstName);

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username.ToLower().StartsWith(search.Username.ToLower())).OrderBy(c => c.FirstName);
            }
            var list =  query.ToList();
            return _mapper.Map<IEnumerable<MUser>>(list);
        }

        public override  MUser GetById(int ID)
        {
            var entity =  _context.Set<User>()
                .Where(i => i.Id == ID)
                .Include(i => i.Role)
                .SingleOrDefault();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<Model.MUser> Insert(UserUpsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }

            var entity = _mapper.Map<User>(request);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<MUser> Update(int ID, UserUpsertRequest request)
        {
            var entity = _context.Users.Find(ID);

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new Exception("Passwords do not match!");
                }

                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }
     
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public async Task<MUser> Authenticate(string Username, string Password)
        {
            var user = await _context.Users
                .Include(i => i.Role)
                .FirstOrDefaultAsync(i => i.Username == Username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, Password);

                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<MUser>(user);
                }
            }
            return null;
        }
        public async Task<MUser> Register(UserRegisterRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }
            UserUpsertRequest newUser = new UserUpsertRequest()
            {
                Username = request.Username,
                BirthDate = request.BirthDate,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                IsActive=true,
                CreateOn = DateTime.Now,
                RoleId=(int)Roles.Registerd,
            };
            var entity = _mapper.Map<User>(newUser);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var entity = await _context.Users.
                Include(i => i.Role).
                FirstOrDefaultAsync(i => i.Id == ID);

            var articleList = await _context.Articles.Where(i => i.UserId == ID).ToListAsync();
            var pollList = await _context.Polls.Where(i => i.UserId == ID).ToListAsync();
            var commentList = await _context.Comments.Where(i => i.UserId == ID).ToListAsync();
            if (!articleList.Any() && !pollList.Any() && !commentList.Any())
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public  async Task<MUser> EditProfile( UserEditProfileRequest request)
        {
            var entity = _context.Users.Find(request.Id);
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Username = request.Username;

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

           
           // _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }

    }
}

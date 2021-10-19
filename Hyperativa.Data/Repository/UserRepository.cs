using Hyperativa.Business.Interfaces.IRepository;
using Hyperativa.Business.Models;
using Hyperativa.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperativa.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<User> ObterUsuario(string name, string password)
        {
            return await Db.Users
                  .Where(u => u.Username.ToLower() == name.ToLower() && u.Password.ToLower() == password).FirstOrDefaultAsync();
        }
    }
}

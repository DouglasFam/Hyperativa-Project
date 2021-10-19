using Hyperativa.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hyperativa.Business.Interfaces.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> ObterUsuario(string name, string password);
    }
}

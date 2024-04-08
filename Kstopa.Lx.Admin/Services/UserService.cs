using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Admin.IServices;
using Kstopa.Lx.SugarDb.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Services
{
    public class UserService : BaseService<UserInfo>, IUserService
    {
        private readonly IUserRepository _db;
        public UserService(IUserRepository repository) : base(repository)
        {
            _db = repository;
        }     
    }
}      


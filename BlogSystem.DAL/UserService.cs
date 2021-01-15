using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using BlogSystem.Model;

namespace BlogSystem.DAL
{
    public class UserService : BaseService<Model.UserModel>,IUserService
    {
        public UserService() : base(new BlogContext())
        {

        }
    }
}

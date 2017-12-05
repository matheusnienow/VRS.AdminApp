using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Model
{
    public class User
    {
        public User(UserDTO x)
        {
            this.Id = x.Id;
            Login = x.Login;
            Salt = x.Salt;
            Hash = x.Hash;
            RoleId = x.RoleId;
        }

        public User(int id, string login, byte[] salt, byte[] hash, int roleId)
        {
            Id = id;
            Login = login;
            Salt = salt;
            Hash = hash;
            RoleId = roleId;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
        public int? RoleId { get; set; }
    }
}

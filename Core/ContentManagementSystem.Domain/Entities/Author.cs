using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Domain.Entities.Common;

namespace ContentManagementSystem.Domain.Entities
{
    public class Author : BaseEntity
    {
        public Guid PostId { get; set; }
        public enum Role
        {
            Admin,
            Editor,
            Author,
            User
        }
        private Role _role;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public Role CurrentRole {
            get { return _role; }
            set { _role = value; }
        }
        public string PasswordHash { get; set; } // Sifre hashlenecek identity
        public string ProfilePicPath { get; set; }
        public Post Post { get; set; }

    }
}

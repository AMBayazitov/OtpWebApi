using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtpWebApi.DAL.Models
{
    public sealed class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Secret { get; set; }

        public string Id { get; set; }
    }
}

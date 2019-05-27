﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtpWebApi.DAL.Models
{
    public sealed class AspNetUser
    {
        public string Id { get; set; }

        public int AccessFailedCount { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public string NormalizedEmail { get; set; }

        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string SecurityStamp { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public string UserName { get; set; }

        public string Secret { get; set; }

    }
}

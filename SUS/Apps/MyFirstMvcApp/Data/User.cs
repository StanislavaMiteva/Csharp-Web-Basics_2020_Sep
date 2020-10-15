﻿using SUS.MVCFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BatlteCards.Data
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Role = IdentityRole.User;
            this.UserCards = new HashSet<UserCard>();
        }        

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}

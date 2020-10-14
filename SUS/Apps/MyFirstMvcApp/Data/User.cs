using SUS.MVCFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BatlteCards.Data
{
    public class User : UserIdentity
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCards = new HashSet<UserCard>();
        }        

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}

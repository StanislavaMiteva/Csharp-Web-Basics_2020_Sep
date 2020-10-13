﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatlteCards.Data
{
    public class UserCard
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}

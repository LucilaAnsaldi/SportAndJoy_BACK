﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sport_and_joy_back_dotnet.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Image { get; set; } = "https://www.clipartkey.com/mpngs/m/152-1520367_user-profile-default-image-png-clipart-png-download.png";

        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Field>? Fields { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

    }
}

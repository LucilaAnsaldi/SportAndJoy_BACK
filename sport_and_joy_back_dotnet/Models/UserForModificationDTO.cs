﻿using sport_and_joy_back_dotnet.Entities;

namespace sport_and_joy_back_dotnet.Models
{
    public class UserForModificationDTO
    {
        public int Id { get; set; }
        public string? Image { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public Erole Role { get; set; }

    }
}

﻿namespace sport_and_joy_back_dotnet.Models
{
    public class ReportUserWithReservationsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ReservationsCount { get; set; }
    }
}

﻿namespace AspNetCoreJwtAuthStarter_Template.Models.DTOs
{
    public class RegisterRequest
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Role { get; set; } = "User"; // default role
    }
}

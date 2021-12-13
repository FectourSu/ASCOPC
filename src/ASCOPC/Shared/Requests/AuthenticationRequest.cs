﻿using System.ComponentModel.DataAnnotations;

namespace ASCOPC.Shared.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

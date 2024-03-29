﻿using System.ComponentModel.DataAnnotations;

namespace ASCOPC.Shared.Requests
{
    public class MessageRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string TextMessage { get; set; }
    }
}

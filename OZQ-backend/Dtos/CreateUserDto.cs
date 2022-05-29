using System;
using System.ComponentModel.DataAnnotations;

namespace ozq_backend.Dtos
{
    public record CreateUserDto
    {
        [Required]
        public string Username { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Contact { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
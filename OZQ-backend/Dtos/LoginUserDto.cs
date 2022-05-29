using System;
using System.ComponentModel.DataAnnotations;

namespace ozq_backend.Dtos
{
    public record LoginUserDto()
    {
        [Required]
        public string Username { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
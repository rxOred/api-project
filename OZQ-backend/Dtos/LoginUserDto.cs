using System;

namespace ozq_backend.Dtos
{
    public record LoginUserDto()
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
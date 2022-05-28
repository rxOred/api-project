using System;

namespace ozq_backend.Dtos
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string Contact { get; init; }
        public string Password { get; init; }
    }
}
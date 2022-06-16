using System;

namespace Ozq.Api.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string Contact { get; init; }
        public string Password { get; init; }
    }
}
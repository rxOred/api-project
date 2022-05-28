using System;

namespace ozq_backend.Dtos
{
    public record OrderDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public DateTimeOffset OrderDate { get; init; }
        public int Total { get; init; }
    }
}
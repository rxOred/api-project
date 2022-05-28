using System;

namespace ozq_backend.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Category { get; init; }
        public int Count { get; set; }
        public int Price { get; init; }
    }
}
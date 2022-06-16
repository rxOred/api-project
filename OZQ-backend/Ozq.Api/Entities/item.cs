using System;

namespace Ozq.Api.Entities
{
    public record Item 
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Category { get; init; }
        public int Count { get; set; }
        public int Price { get; init; }
        public string Image { get; init; }
        public string Description { get; init; }
    }
}
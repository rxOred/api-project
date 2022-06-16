using System;
using System.ComponentModel.DataAnnotations;

namespace Ozq.Api.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Category { get; init; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; init; }
        [Required]
        public string Image { get; init; }
        [Required]
        public string Description { get; init; }
    }
}
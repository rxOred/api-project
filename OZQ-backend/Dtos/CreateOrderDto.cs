using System;
using System.ComponentModel.DataAnnotations;

namespace ozq_backend.Dtos
{
    public record CreateOrderDto
    {
        [Required]
        public int Total { get; init; }
    }
}
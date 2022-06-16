using System;
using System.ComponentModel.DataAnnotations;

namespace Ozq.Api.Dtos
{
    public record CreateOrderDto
    {
        [Required]
        public int Total { get; init; }
    }
}
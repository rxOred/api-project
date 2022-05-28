using System;

namespace ozq_backend.Dtos
{
    public record CreateOrderDto
    {
        public int Total { get; init; }
    }
}
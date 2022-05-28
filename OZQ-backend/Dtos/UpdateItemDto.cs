using System;
using System.ComponentModel.DataAnnotations;

namespace ozq_backend.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public int Count { get; set; }
    }
}
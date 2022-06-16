using System;
using System.ComponentModel.DataAnnotations;

namespace Ozq.Api.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public int Count { get; set; }
    }
}
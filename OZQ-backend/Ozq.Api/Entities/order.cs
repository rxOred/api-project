using System;

namespace Ozq.Api.Entities
{
    public record Order
    {
        public Guid Id { get; init; }
        public Guid UserId {get; init;}
        public DateTimeOffset OrderDate {get; init;}
        public int Total {get; init; }
    }
}
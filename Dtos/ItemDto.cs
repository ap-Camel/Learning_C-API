using System;

namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string name { get; init; }
        public decimal price {get; init;}
        public DateTimeOffset createdDate { get; init; }
    }
}